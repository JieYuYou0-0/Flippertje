using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using GhibliFlix.jsonClasses;

namespace GhibliFlix.menus
{
    internal class MenuOverview : Menu
    {
        private readonly MembershipMenu membershipMenu;

        internal MenuOverview()
        {
            AddMenuOption(MembershipLogin, ConsoleKey.D1, Session.Settings.GuestMenuLogin);
            AddMenuOption(MembershipLogin, ConsoleKey.D2, Session.Settings.GuestMenuRegister);

            membershipMenu = new MembershipMenu();
            membershipMenu.PreviousMenu = Init;
        }

        internal override void Init()
        {
            Console.Clear();
            Log("Princess Monoke opens the menuOverview");
            Console.WriteLine(Session.Settings.GuestMenuTitle);
            ShowMenu();
        }

        internal void MembershipLogin()
        {
            Log("Members Login");
            string jsonString = File.ReadAllText("json_files/members.json");
            Members members = JsonSerializer.Deserialize<Members>(jsonString);

            PreviousStep = Init;
            Console.WriteLine(Session.Settings.MembershipLogin);
            while (true)
            {
                string answer = ReadLine();

                // Find first member with code
                Member member = members.members.FirstOrDefault(member => member.Code == answer);

                if (member != null)
                {
                    Session.User = member;
                    membershipMenu.Init();
                }
                else
                {
                    Console.WriteLine(Session.Settings.InvalidMembershipCode);
                }
            }
        }

        internal void CreateMemberShip()
        {
            Log("Create Membership");
            Console.Clear();

            // request data
            var userInfo = RequestUserData();
            string code = CreateMembershipCode();
            SendMail(userInfo["email"]);

            // save data
            SaveMembership(userInfo["name"], code, userInfo["email"], userInfo["creditcard"]);

            string htmlBody = File.ReadAllText(@"emailTemplates/acc_confirmationMail.txt");

            List<string> emails = new List<string> { userInfo["email"] };
            htmlBody = htmlBody.Replace("**name**", userInfo["name"]);
            htmlBody = htmlBody.Replace("**code**", code);
            MailSender.SendConfirmationMail(htmlBody, emails, "Account Confirmation");

            // send response
            string response = Session.Settings.MembershipCreated;
            Console.WriteLine(string.Format(response, userInfo["name"], code));
            WaitForInput();

            // open membership menu
            string membersJson = File.ReadAllText("json_files/memberships.json");
            Members members = JsonSerializer.Deserialize<Members>(membersJson);

            // Set Session user obj and open membership menu
            Session.User = members.members.First(member => member.Code == code);
            membershipMenu.Init();
        }

        private void SendMail(string mail)
        {
            string htmlBody = File.ReadAllText(@"emailTemplates/acc_confirmationMail.txt");

            Guid myuuid = Guid.NewGuid();
            string verificationCode = myuuid.ToString();

            htmlBody = htmlBody.Replace("**code**", verificationCode);

            PreviousStep = Init;

            Console.Clear();


            MailSender.SendVerificationEmail(htmlBody, mail, Session.Settings.EmailAccVerification);
            Console.WriteLine(Session.Settings.VerificationCodeSend);

            while (true)
            {
                if (ReadLine(show: true) == verificationCode)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine(Session.Settings.EnteredWrongCode);
                }
            }
        }

        private Dictionary<string, string> RequestUserData()
        {
            Log("Request User Data");

            Dictionary<string, string> values = new Dictionary<string, string>();

            Name();

            void Name()
            {
                Console.Clear();
                Console.WriteLine(Session.Settings.EnterFullName);
                PreviousStep = Init;

                string input = ReadLine();
                if (input == null) return;

                values["name"] = input;
                Email();
            }

            void Email()
            {
                Console.Clear();
                Console.WriteLine(Session.Settings.EnterEmail);
                PreviousStep = Name;

                string input = ReadLine();
                if (input == null) return;

                values["email"] = input;
                Creditcard();
            }

            void Creditcard()
            {
                Console.Clear();
                Console.WriteLine(Session.Settings.EnterCreditcard);
                PreviousStep = Email;

                string input = ReadLine();
                if (input == null) return;

                values["creditcard"] = input;
            }

            return values;
        }

        private static string CreateMembershipCode()
        {
            Log("Princess Monoke is creating a random MembershipCode");
            Random rnd = new Random();
            string str = "";
            for (int i = 0; i < 3; i++)
            {
                int RandomNumber = rnd.Next(0, 10);
                char RandomChar = (char)rnd.Next('a', 'z');
                str = str + RandomNumber + RandomChar;
            }

            string MembershipCode = new string(str.ToCharArray().OrderBy(s => (rnd.Next(2) % 2) == 0).ToArray());
            return MembershipCode;
        }

        private static void SaveMembership(string name, string code, string mail, string creditcard)
        {
            Log("Butler saves membership in JSON");
            string membersJson = File.ReadAllText("json_files/members.json");
            Members members = JsonSerializer.Deserialize<Members>(membersJson);

            Member newMember = new Member
            {
                Name = name,
                Code = code,
                Email = mail,
                Creditcard = creditcard,
            };
            members.members.Add(newMember);

            string newMembersJson = JsonSerializer.Serialize(members);
            File.WriteAllText("json_files/members.json", newMembersJson);
        }

    }
}
