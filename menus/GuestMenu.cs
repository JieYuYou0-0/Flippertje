using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace GhibliFlix
{
    class GuestMenu : Menu
    {
        private readonly MembershipMenu membershipMenu;
        private readonly AdminMenu AdminMenu;
        private const string AdminMenuCode = "admin";

        public GuestMenu()
        {
            AddMenuOption(MembershipLogin, ConsoleKey.D1, Session.Language.GuestMenuLogin);
            AddMenuOption(CreateMembership, ConsoleKey.D2, Session.Language.GuestMenuRegister);
            //AddMenuOption(ShowRandomReview, ConsoleKey.D3, Session.Language.GuestMenuReview);

            this.membershipMenu = new MembershipMenu();
            AdminMenu = new AdminMenu();

            this.membershipMenu.PreviousStep = Init;
            AdminMenu.PreviousStep = Init;
        }

        public override void Init()
        {
            Console.Clear();
            Log("Open GuestMenu");

            Console.WriteLine(Session.Language.GuestMenuTitle);
            ShowMenu();
        }

        public void MembershipLogin()
        {
            Log("Membership Login");
            string jsonString = File.ReadAllText("jsonFiles/memberships.json");
            Members members = JsonSerializer.Deserialize<Members>(jsonString);

            PreviousStep = Init;

            Console.WriteLine(Session.Language.MembershipLogin);

            while (true)
            {
                string answer = ReadLine();

                if (answer == AdminMenuCode)
                {
                    AdminMenu.Init(); // Opens the secret Admin menu if the input is 'sesame'
                }
                else
                {
                    // Find first member with code
                    Member member = members.members.FirstOrDefault(member => member.Code == answer);

                    if (member != null)
                    {
                        Session.User = member;
                        membershipMenu.Init();
                    }
                    else
                    {
                        Console.WriteLine(Session.Language.InvalidMembershipCode);
                    }
                }
            }
        }

        #region Membership Creation
        public void CreateMembership()
        {
            Log("Create Membership");
            Console.Clear();

            // request data
            var userInfo = RequestUserData();
            string code = CreateMembershipCode();

            SendMail(userInfo["email"]);

            // save data
            SaveMembership(userInfo["name"], code, userInfo["email"], userInfo["creditcard"]);

            string htmlBody = File.ReadAllText(@"emailTemplates/accountConfirmationMail.txt");
            List<string> emails = new List<string> { userInfo["email"] };
            htmlBody = htmlBody.Replace("**name**", userInfo["name"]);
            htmlBody = htmlBody.Replace("**code**", code);
            //htmlBody = htmlBody.Replace("**allergies**", userInfo["allergies"]);
            MailSender.SendConfirmationEmail(htmlBody, emails, "Account Confirmation");

            // send response
            string response = Session.Language.MembershipCreated;
            Console.WriteLine(string.Format(response, userInfo["name"], code));
            WaitForInput();

            // open membership menu
            string membersJson = File.ReadAllText("jsonFiles/memberships.json");
            Members members = JsonSerializer.Deserialize<Members>(membersJson);

            // Set Session user obj and open membership menu
            Session.User = members.members.First(member => member.Code == code);
            membershipMenu.Init();
        }

        private void SendMail(string mail)
        {
            string htmlBody = File.ReadAllText(@"emailTemplates/accountVerificationMail.txt");

            Guid myuuid = Guid.NewGuid();
            string verificationCode = myuuid.ToString();
            //string verificationCode = CreateMembershipCode();

            htmlBody = htmlBody.Replace("**code**", verificationCode);

            PreviousStep = Init;

            Console.Clear();

            MailSender.SendVerificationEmail(htmlBody, mail, Session.Language.EmailAccountVerification);
            Console.WriteLine(Session.Language.VerificationCodeSend);

            while (true)
            {
                if (ReadLine(show: true) == verificationCode)
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine(Session.Language.EnteredWrongCode);
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
                Console.WriteLine(Session.Language.EnterFullName);
                PreviousStep = Init;

                string input = ReadLine();
                if (input == null)
                {
                    return;
                }

                values["name"] = input;
                Email();
            }

            void Email()
            {
                Console.Clear();
                Console.WriteLine(Session.Language.EnterEmail);
                PreviousStep = Name;

                string input = ReadLine();
                if (input == null)
                {
                    return;
                }

                values["email"] = input;
                Creditcard();
            }

            void Creditcard()
            {
                Console.Clear();
                Console.WriteLine(Session.Language.EnterCreditcard);
                PreviousStep = Email;

                string input = ReadLine();
                if (input == null)
                {
                    return;
                }

                values["creditcard"] = input;
                //Allergies();
            }

            return values;
        }

        public static string CreateMembershipCode()
        {
            Log("GhibliFlix creates random MembershipCode");
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

        public static void SaveMembership(string name, string code, string mail, string creditcard)
        {
            Log("GhibliFlix saves membership in JSON");
            string membersJson = File.ReadAllText("jsonFiles/memberships.json");
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
            File.WriteAllText("jsonFiles/memberships.json", newMembersJson);
        }
        #endregion
    }
}
