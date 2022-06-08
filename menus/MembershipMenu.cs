using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;
using GhibliFlix.menus;

namespace GhibliFlix
{
    internal class MembershipMenu : Menu
    {
        internal MembershipMenu()
        {
            CreateReservationMenu createReservationMenu = new CreateReservationMenu();
            createReservationMenu.PreviousMenu = Init;

            AddMenuOption(MembershipOverview, ConsoleKey.D1, Session.Settings.MembershipOverview);
            AddMenuOption(createReservationMenu.Init, ConsoleKey.D2, Session.Settings.MembershipCreateReservation);
            AddMenuOption(CancelReservation, ConsoleKey.D3, Session.Settings.MembershipCancelReservation);

        }

        internal override void Init()
        {
            Console.Clear();
            Menu.Log("Opens Membership Menu");
            MenuOverview menuOverview = new MenuOverview();
            PreviousMenu = menuOverview.Init;

            string greet = Session.Settings.MembershipMenuGreet;
            Console.WriteLine(string.Format(greet, Session.User.Name));
            Console.WriteLine(Session.Settings.MembershipMenuTitle);
            ShowMenu();
        }

        internal void MembershipOverview()
        {

        }

        internal void CancelReservation()
        {
            Log("Cancel Reservation Menu");

            PreviousStep = Init;
            Console.Clear();

            int indexReservation = 0;
            bool bcontinue = false;

            Console.WriteLine(Session.Settings.CancelReservation);
            Console.WriteLine(Session.Settings.AskVerificationCode);

            string VerificatieCode = ReadLine();
            string json = File.ReadAllText("json_files/reservations.json");
            var Reservations = JsonSerializer.Deserialize<Reservations>(json);

            int ReservationsAmount = Reservations.reservations.Count;
            for (int i = 0; i < ReservationsAmount; i++)
            {
                if (Reservations.reservations[i].ReservationId == VerificatieCode)
                {
                    indexReservation = i;
                    bcontinue = true;
                }
            }

            if (bcontinue == false)
            {
                Menu.Log("Input invalid for cancel reservation");
                Console.WriteLine(Session.Settings.InvalidInput);
                PreviousStep = CancelReservation;
                ReadBackInput();
            }

            DateTime now = DateTime.Now;
            string dateInput = Reservations.reservations[indexReservation].ReservationDate;
            DateTime parsedDate = DateTime.Parse(dateInput);
            int differenceInDates = (parsedDate - now).Days;

            if (differenceInDates < 7)
            {
                bcontinue = false;
                Console.WriteLine(Session.Settings.CancelTooLate);
                PreviousStep = Init;
                ReadBackInput();

            }

            if (bcontinue == true)
            {
                Console.WriteLine(Session.Settings.ReservationCancelOptions);
                string keuze = ReadLine();
                if (keuze == "1")
                {
                    // Completely deleted
                    Menu.Log("Howl removes everything from reservation");
                    PreviousStep = Init;

                    Reservations.reservations[indexReservation].Cancelled = true;
                    string Newjson = JsonSerializer.Serialize(Reservations);

                    File.WriteAllText("json_files/reservations.json", Newjson);
                    Console.WriteLine(Session.Settings.ReservationCanceled);
                }
                else if (keuze == "2")
                {
                    Menu.Log("Howl removes guests from reservation");
                    PreviousStep = Init;

                    // Partly deleted
                    Console.WriteLine(Session.Settings.NamesToRemove);
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
                    File.WriteAllText("json_files/reservations.json", json2);

                    Console.WriteLine(Session.Settings.ReservationChanged);
                }
                else
                {
                    Console.WriteLine(Session.Settings.InvalidInput);
                    PreviousStep = CancelReservation;
                    ReadBackInput();
                }

                string htmlBody = File.ReadAllText(@"emailTemplates/reservation_cancelConfirmation.txt");
                List<string> email = new List<string> { Session.User.Email };

                MailSender.SendConfirmationMail(htmlBody, email, Session.Settings.EmailCancelRes);
                ReadBackInput();

            }
        }
    }
}
