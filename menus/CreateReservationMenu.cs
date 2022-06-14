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
    internal class CreateReservationMenu : Menu
    {
        internal Reservation res;
        internal DateTime reservationDate;
        internal CreateReservationMenu()
        {
            string json = File.ReadAllText("json_files/movies.json");
            MovieOverview allMovies = JsonSerializer.Deserialize<MovieOverview>(json);
        }

        internal override void Init()
        {
            Log("Start Creating Reservation");
            Console.Clear();
            Console.WriteLine(string.Format(Session.Settings.ReservationMenuGreet, Session.User.Name));

            WaitForInput();
        }

        internal void CreateReservation()
        {
            Log("Create Reservation");

            Reservations.Save(res);
        }


        internal void SelectMovie()
        {
            Log("Selecting movies");
            Console.Clear();

            int choiceIndex = 0;

            while (true)
            {
                ConsoleKeyInfo input = ReadKey();

                if (input.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    var movieChoice = new MovieOverview();
                    movieChoice.GetTitles();
                    break;
                }
                else if (input.Key == ConsoleKey.DownArrow && choiceIndex > 0)
                {
                    choiceIndex--;
                }
                else if (input.Key == ConsoleKey.UpArrow && choiceIndex < -1)
                {
                    choiceIndex++;
                }
            }
        }

        internal void AskDate()
        {
            SettingDate date = new SettingDate();
            date.GetDateInput();
        }

        internal void ViewLayout()
        {
            Log("Show Layout");
            PreviousStep = AskDate;

        }
        //internal void ViewLayout(List<int> seats)
        //{
        //    Log("Show Layout");
        //    PreviousStep = AskDate;

        //    string fullRow = "############################";
        //    string emptyRow = "#                          #";

        //    res.SeatNumber = seats.Count;

        //    int maxRowPopulation = 24;
        //    int rowPopulation = 0;
        //    int currentColumns = 1;

        //    Console.Clear();
        //    Console.WriteLine(string.Format(Session.Settings.NotifySeatNumber, res.SeatNumber));
        //    Console.WriteLine(fullRow);
        //    Console.WriteLine(emptyRow);
        //    Console.Write("#");

        //    for (int i = 0; i < seats.Count; i++)
        //    {
        //        string table = CreateTable(seats[i]);

        //        if (rowPopulation + table.Length > maxRowPopulation)
        //        {
        //            CompleteRow(rowPopulation);
        //            Console.WriteLine(emptyRow);
        //            Console.Write("#");
        //            WriteTable(table, i == seats.Count - 1);
        //            rowPopulation = table.Length;
        //            currentColumns++;
        //        }
        //        else
        //        {
        //            WriteTable(table, i == seats.Count - 1);
        //            rowPopulation += table.Length;
        //        }
        //    }

        //    CompleteRow(rowPopulation);
        //    WriteMissingRows();
        //    Console.WriteLine(emptyRow);
        //    Console.WriteLine(fullRow);

        //    WaitForInput();
        //    void CompleteRow(int rowLength)
        //    {
        //        Console.Write(string.Concat(Enumerable.Repeat(" ", maxRowPopulation - rowLength + 2)) + "#\n");
        //    }

        //    void WriteMissingRows()
        //    {
        //        int requiredColumns = 3;

        //        string remainingRows = string.Concat(Enumerable.Repeat(emptyRow + "\n", (requiredColumns - currentColumns) * 2));

        //        Console.Write(remainingRows);
        //    }

        //    string CreateTable(int guests)
        //    {
        //        if (guests == 0 || guests == 1)
        //            return "  []";
        //        return "  [" + string.Concat(Enumerable.Repeat(".", guests - 2)) + "]";
        //    }

        //    void WriteTable(string table, bool color)
        //    {
        //        if (color)
        //        {
        //            Console.ForegroundColor = ConsoleColor.DarkRed;

        //        }

        //        Console.Write(table);

        //        if (color)
        //        {
        //            Console.ResetColor();

        //        }
        //    }

        //}
        internal void SendConfirmationMail(Reservation reservation)
        {
            string htmlBody = File.ReadAllText(@"emailTemplates/reservation_confirmationMail.txt");

            htmlBody = htmlBody.Replace("**reservation_creation**", reservation.DateOfCreation);
            htmlBody = htmlBody.Replace("**reservation**", reservation.ReservationDate);
            htmlBody = htmlBody.Replace("**table**", reservation.SeatNumber.ToString());
            htmlBody = htmlBody.Replace("**reservation_id**", reservation.ReservationId);

            var emailList = new List<string>();
            emailList.Add(Session.User.Email);

            MailSender.SendConfirmationMail(htmlBody, emailList, Session.Settings.EmailReservationConfirmation);
        }

    }
}
