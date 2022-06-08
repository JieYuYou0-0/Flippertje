using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix.menus
{
    internal class CreateReservationMenu : Menu
    {
        
        internal CreateReservationMenu()
        {

        }

        internal override void Init()
        {

        }

        internal void CreateReservation()
        {
            Log("Create Reservation");
            AskName();Name(); // Initial Prompt

            // Payment...

            ReservationSummary();

            Reservations.Save(res);
            SendConfirmationMail(res);
        }

        internal void AskName()
        {
            Log("Ask Name");
            Console.Clear();
            PreviousStep = Init;

            // Display name of previously added guest
            if (currentGuest != null)
                Console.WriteLine(string.Format(Session.Settings.GuestAdded, currentGuest.Name));

            Console.WriteLine(Session.Settings.AskForGuests);

            string input = ReadLine();
            if (input == null) return;
            else if (input == "") // empty string means user doesn't want to input any more guests
            {
                // add the user as a guest (the host)
                currentGuest = Session.User;
                res.Guests.Add(currentGuest);
                SelectMenu();
                return;
            }

            currentGuest = new Guest();
            currentGuest.Name = input;
            res.Guests.Add(currentGuest);
            AskEmail();

        }

        internal void AskEmail()
        {
            void BackToNamePrompt()
            {
                // This function removes the current guest from the guestList and then goes back to the previous prompt
                res.Guests.RemoveAt(res.Guests.Count - 1);
                currentGuest = res.Guests.LastOrDefault();
                AskGuestName();
            }

            Log("Ask Guest Email");
            PreviousStep = BackToNamePrompt;

            Console.Clear();
            Console.WriteLine(string.Format(Session.Settings.EnterGuestMail, currentGuest.Name));

            string input = ReadLine();
            if (input == null) return;

            currentGuest.Email = input;

        }

        internal void SelectMovie()
        {
            Log("Selecting Menu");
            Console.Clear();
            PreviousStep = AskForAllergies;

            int choiceIndex = 0;

            while (true)
            {
                RenderMenuOptions();

                ConsoleKeyInfo input = ReadKey();

                if (input.Key == ConsoleKey.Escape)
                    return;
                else if (input.Key == ConsoleKey.Enter)
                {
                    var menuChoice = menus[choiceIndex];
                    currentGuest.MenuChoice = menuChoice.GetType().Name;
                    res.TotalCost += menuChoice.Price;
                    break;
                }
                else if (input.Key == ConsoleKey.LeftArrow && choiceIndex > 0)
                    choiceIndex--;
                else if (input.Key == ConsoleKey.RightArrow && choiceIndex < menus.Length - 1)
                    choiceIndex++;
            }

            void RenderMenuOptions()
            {
                Console.Clear();

                if (currentGuest == Session.User)
                    Console.WriteLine(Session.Settings.AskMenuChoice);
                else
                    Console.WriteLine(Session.Settings.SelectMenu);

                Console.Write("<- ");
                for (int i = 0; i < menus.Length; i++)
                {
                    Console.Write("|  ");

                    if (choiceIndex == i) Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write($"{menus[i].GetType().Name}  ");

                    if (choiceIndex == i) Console.ResetColor();
                }
                Console.Write("| ->\n\n");
                Console.WriteLine("Price: " + menus[choiceIndex].Price + " Euro");
            }

        }

        internal void AskDate()
        {
            Log("Ask For Date");

            if (currentGuest == null)
                PreviousStep = AskName;

            Console.Clear();
            Console.WriteLine(Session.Settings.EnterDate);

            reservationDate = FindNextOpenDate(DateTime.Today.AddDays(1), res.Guests.Count); // default

            while (true)
            {
                string input = ReadLine(show: true);

                if (input == "") // user has confirmed the date
                    break;
                else if (input == "1") // User inputted enter; suggest a date
                {
                    reservationDate = FindNextOpenDate(reservationDate, res.Guests.Count);
                    Console.WriteLine(string.Format(Session.Settings.ConfirmSuggestedDate, reservationDate.ToShortDateString()));
                }
                else if (DateTime.TryParse(input, out reservationDate)) // Check if Date is valid
                {
                    var isDateAvailable = IsDateAvailable(reservationDate, res.Guests.Count);

                    if (isDateAvailable.Item1) // Date is Valid and available, so continue
                        break;
                    else
                        Console.WriteLine(isDateAvailable.Item2); // Prints Reason why date is not available
                }
                else
                    Console.WriteLine(Session.Settings.InvalidDate);
            }

            ViewLayout(CreateSeatList(reservationDate, res.Guests.Count));

        }

        internal void ViewLayout(List<int> seats)
        {
            Log("Show Layout");
            PreviousStep = AskForDate;

            string fullRow = "############################";
            string emptyRow = "#                          #";

            res.TableNumber = tables.Count;

            int maxRowPopulation = 24;
            int rowPopulation = 0;
            int currentColumns = 1;

            Console.Clear();
            Console.WriteLine(string.Format(Session.Settings.NotifySeatNumber, res.SeatNumber));
            Console.WriteLine(fullRow);
            Console.WriteLine(emptyRow);
            Console.Write("#");

            for (int i = 0; i < tables.Count; i++)
            {
                string table = CreateTable(tables[i]);

                if (rowPopulation + table.Length > maxRowPopulation)
                {
                    CompleteRow(rowPopulation);
                    Console.WriteLine(emptyRow);
                    Console.Write("#");
                    WriteTable(table, i == tables.Count - 1);
                    rowPopulation = table.Length;
                    currentColumns++;
                }
                else
                {
                    WriteTable(table, i == tables.Count - 1);
                    rowPopulation += table.Length;
                }
            }

            CompleteRow(rowPopulation);
            WriteMissingRows();
            Console.WriteLine(emptyRow);
            Console.WriteLine(fullRow);

            WaitForInput();

        }
        internal void CompleteRow(int rowLength)
        {
            Console.Write(string.Concat(Enumerable.Repeat(" ", maxRowPopulation - rowLength + 2)) + "#\n");
        }

        internal void WriteMissingRows()
        {
            int requiredColumns = 3;

            string remainingRows = string.Concat(Enumerable.Repeat(emptyRow + "\n", (requiredColumns - currentColumns) * 2));

            Console.Write(remainingRows);
        }

        internal string CreateTable(int guests)
        {
            if (guests == 0 || guests == 1)
                return "  []";
            return "  [" + string.Concat(Enumerable.Repeat(".", guests - 2)) + "]";
        }

        internal void WriteTable(string table, bool color)
        {
            if (color)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;

            }

            Console.Write(table);

            if (color)
            {
                Console.ResetColor();

            }
        }
    }
}
