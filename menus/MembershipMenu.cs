using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Net;
using System.Net.Mail;

namespace GhibliFlix
{
    class MembershipMenu : Menu
    {
        public MembershipMenu()
        {
            CreateReservationMenu createReservationMenu = new CreateReservationMenu();
            createReservationMenu.PreviousMenu = Init;

            AddMenuOption(MembershipOverview, ConsoleKey.D1, Session.Language.MembershipOverview);
            AddMenuOption(createReservationMenu.Init, ConsoleKey.D2, Session.Language.MembershipCreateReservation);
            AddMenuOption(CancelReservation, ConsoleKey.D3, Session.Language.MembershipCancelReservation);
        }

        public override void Init()
        {
            Console.Clear();
            Menu.Log("Opens Membership Menu");
            GuestMenu guestmenu = new GuestMenu();
            PreviousMenu = guestmenu.Init;

            string greet = Session.Language.MembershipMenuGreet;
            Console.WriteLine(string.Format(greet, Session.User.Name));
            Console.WriteLine(Session.Language.MembershipMenuTitle);
            ShowMenu();
        }

        #region Cancel Reservation
        public void CancelReservation()
        {

            Log("Cancel Reservation Menu");

            PreviousStep = Init;
            Console.Clear();

            int indexReservation = 0;
            bool bDoorgaan = false;

            Console.WriteLine(Session.Language.CancelReservation);
            Console.WriteLine(Session.Language.AskVerificationCode);

            string VerificatieCode = ReadLine();
            //var OpenReservation = Reservations.FetchAll();

            string json = File.ReadAllText("jsonFiles/reservations.json");
            var Reservations = JsonSerializer.Deserialize<Reservations>(json);

            int ReservationsAmount = Reservations.reservations.Count;
            for (int i = 0; i < ReservationsAmount; i++)
            {
                //var open = Reservations.reservations[i];
                if (Reservations.reservations[i].ReservationId == VerificatieCode)
                {
                    indexReservation = i;
                    bDoorgaan = true;
                }
            }
            if (bDoorgaan == false)
            {
                Menu.Log("Input invalid for cancel reservation");
                Console.WriteLine(Session.Language.InvalidInput);
                PreviousStep = CancelReservation;
                ReadBackInput();
            }

            DateTime now = DateTime.Now;
            string dateInput = Reservations.reservations[indexReservation].ReservationDate;
            DateTime parsedDate = DateTime.Parse(dateInput);
            int differenceInDates = (parsedDate - now).Days;

            if (differenceInDates < 7)
            {
                bDoorgaan = false;
                Console.WriteLine(Session.Language.CancelTooLate);
                PreviousStep = Init;
                ReadBackInput();

            }
            if (bDoorgaan == true)
            {
                Console.WriteLine(Session.Language.ReservationCancelOptions);
                string keuze = ReadLine();
                if (keuze == "1")
                {
                    //Volledig verwijderen
                    Menu.Log("GhibliFlix removes whole reservation");
                    PreviousStep = Init;

                    Reservations.reservations[indexReservation].Cancelled = true;
                    string Newjson = JsonSerializer.Serialize(Reservations);

                    File.WriteAllText("jsonFiles/reservations.json", Newjson);
                    Console.WriteLine(Session.Language.ReservationCanceled);
                }
                else if (keuze == "2")
                {
                    Menu.Log("GhibliFlix removes guests from reservation");
                    PreviousStep = Init;

                    //Deels verwijderen
                    //Console.WriteLine(Session.Language.NamesToRemove);
                    string namesInput = Console.ReadLine();
                    char[] delimiterChars = { ' ', ',', '.' };
                    string[] words = namesInput.Split(delimiterChars);
                    var Guests = Reservations.reservations[indexReservation].Guests;
                    for (int i = 0; i < Guests.Count; i++)
                    {
                        var GuestName = Guests[i].Name;
                        foreach (var word in words)
                        {
                            if (GuestName.ToLower() == word.ToLower())
                            {
                                Guests.RemoveAt(i);
                            }
                        }
                    }

                    string json2 = JsonSerializer.Serialize(Reservations);
                    File.WriteAllText("jsonFiles/reservations.json", json2);

                    Console.WriteLine(Session.Language.ReservationChanged);
                }
                else
                {
                    Console.WriteLine(Session.Language.InvalidInput);
                    PreviousStep = CancelReservation;
                    ReadBackInput();
                }

                string htmlBody = htmlBody = File.ReadAllText(@"emailTemplates/reservationCancelConfirmation.txt");
                List<string> email = new List<string> { Session.User.Email };

                MailSender.SendConfirmationEmail(htmlBody, email, Session.Language.EmailCancelReservation);
                ReadBackInput();
            }
        }

        #endregion Cancel Reservation

        #region Membership Overview
        public void MembershipOverview()
        {
            Menu.Log("GhibliFlix opens MembershipOverview");
            PreviousStep = Init;

            string settingsJson = File.ReadAllText("jsonFiles/memberships.json");
            Members memberList = JsonSerializer.Deserialize<Members>(settingsJson);
            Member member = memberList.members.FirstOrDefault(x => x.Code == Session.User.Code);

            string creditcardCencored = "";
            for (int i = 0; i < member.Creditcard.Length; i++)
            {
                if (i < member.Creditcard.Length - 3)
                {
                    creditcardCencored += "*";
                }
                else
                {
                    creditcardCencored += member.Creditcard[i];
                }
            }

            Console.Clear();
            Console.WriteLine(
                "Name:\t" + member.Name +
                "\nEmail:\t" + member.Email +
                "\nCode:\t" + member.Code +
                "\nCreditcard:\t" + creditcardCencored);
            ReadBackInput();
        }
        #endregion Membership Overview
    }
}