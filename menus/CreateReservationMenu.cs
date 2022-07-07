using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace GhibliFlix
{
    class CreateReservationMenu : Menu
    {
        Reservation res;
        DateTime reservationDate;
        Guest currentGuest = null;
        private readonly MovieCollection.Movie[] movieArr;
        private MovieCollection.Movie movie1 = new MovieCollection.Movie1();
        private MovieCollection.Movie movie2 = new MovieCollection.Movie2();
        private MovieCollection.Movie movie3 = new MovieCollection.Movie3();
        private MovieCollection.Movie movie4 = new MovieCollection.Movie4();
        private MovieCollection.Movie movie5 = new MovieCollection.Movie5();
        private MovieCollection.Movie movie6 = new MovieCollection.Movie6();
        private MovieCollection.Movie movie7 = new MovieCollection.Movie7();
        private MovieCollection.Movie movie8 = new MovieCollection.Movie8();

        public CreateReservationMenu()
        {
            string json = File.ReadAllText("jsonFiles/movies.json");
            MovieCollection allMovies = JsonSerializer.Deserialize<MovieCollection>(json);

            this.movieArr = new MovieCollection.Movie[] { allMovies.Movie_1, allMovies.Movie_2, allMovies.Movie_3, allMovies.Movie_4, allMovies.Movie_5, allMovies.Movie_6, allMovies.Movie_7, allMovies.Movie_8 };
        }

        public override void Init()
        {
            Log("Create Reservation Start");
            Console.Clear();
            Console.WriteLine(string.Format(Session.Language.ReservationMenuGreet, Session.User.Name));

            WaitForInput();

            res = new Reservation
            {
                Guests = new List<Guest>()
            };

            CreateReservation();
        }

        public void CreateReservation()
        {
            Log("Create Reservation");
            AskGuestName(); // Initial Prompt

            Reservations.Save(res);
            SendConfirmationMail(res);

            GotoPreviousMenu();
        }

        #region Guest Details
        private void AskGuestName()
        {
            Log("Ask Name");
            Console.Clear();

            if (res.Guests.Count > 0)
            {
                PreviousStep = AskGuestName;
            }
            else
            {
                PreviousStep = Init;
            }

            // Display name of previously added guest
            if (currentGuest != null)
            {
                Console.WriteLine(string.Format(Session.Language.GuestAdded, currentGuest.Name));
            }

            Console.WriteLine(Session.Language.AskForGuests);

            string input = ReadLine();
            if (input == null)
            {
                // The user is being added as a host
                currentGuest = Session.User;
                res.Guests.Add(currentGuest);
                SelectMovie();
                return;
            }

            currentGuest = new Guest();
            currentGuest.Name = input;
            res.Guests.Add(currentGuest);
            AskForEmail();
        }

        private void AskForEmail()
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
            Console.WriteLine(string.Format(Session.Language.EnterGuestMail, currentGuest.Name));

            string input = ReadLine();
            if (input == null)
            {
                return;
            }
            currentGuest.Email = input;

            SelectMovie();
        }

        public void SelectMovie()
        {
            Log("Selecting Movie");
            Console.Clear();
            PreviousStep = AskForEmail;

            while (true)
            {
                ConsoleKeyInfo input = ReadKey();
                if (input.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if(input.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine($"Choose between 1 and {(this.movieArr.Length - 1) + 1}:\n\n" +
                                      $"[1] {this.movie1.Title}\n" +
                                      $"[2] {this.movie2.Title}\n" +
                                      $"[3] {this.movie3.Title}\n" +
                                      $"[4] {this.movie4.Title}\n" +
                                      $"[5] {this.movie5.Title}\n" +
                                      $"[6] {this.movie6.Title}\n" +
                                      $"[7] {this.movie7.Title}\n" +
                                      $"[8] {this.movie8.Title}\n");

                    var movieChoice = Convert.ToInt32(Console.ReadLine());

                    if (movieChoice == 1)
                    {
                        currentGuest.movieChoice = this.movie1.Title;
                        Console.WriteLine($"You chose: My Neighbor Totoro");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }

                    if (movieChoice == 2)
                    {
                        currentGuest.movieChoice = this.movie2.Title;
                        Console.WriteLine($"You chose: Howl's Moving Castle");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    if (movieChoice == 3)
                    {
                        currentGuest.movieChoice = this.movie3.Title;
                        Console.WriteLine($"You chose: Princess Mononoke");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    if (movieChoice == 4)
                    {
                        currentGuest.movieChoice = this.movie4.Title;
                        Console.WriteLine($"You chose: Kiki's Delivery Service");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    if (movieChoice == 5)
                    {
                        currentGuest.movieChoice = this.movie5.Title;
                        Console.WriteLine($"You chose: Ponyo");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    if (movieChoice == 6)
                    {
                        currentGuest.movieChoice = this.movie6.Title;
                        Console.WriteLine($"You chose: Spirited Away");
                        Console.ReadLine();
                        RenderMovieOptions();

                    }
                    if (movieChoice == 7)
                    {
                        currentGuest.movieChoice = this.movie7.Title;
                        Console.WriteLine($"You chose: The Cat Returns");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    if (movieChoice == 8)
                    {
                        currentGuest.movieChoice = this.movie8.Title;
                        Console.WriteLine($"You chose: The Wind Rises");
                        Console.ReadLine();
                        RenderMovieOptions();
                    }
                    return;
                }
            }

            void RenderMovieOptions()
            {
                Console.Clear();

                if (currentGuest == Session.User)
                {
                    Console.WriteLine(Session.Language.AskMovieChoice);
                }
                else
                {
                    Console.WriteLine(Session.Language.SelectMovie);
                }
                AskForDate();
            }
        }

        public void AskForDate()
        {
            Log("Ask For Date");

            if (currentGuest == null)
            {
                PreviousStep = AskGuestName;
            }
            else
            {
                PreviousStep = SelectMovie;
            }

            Console.Clear();
            Console.WriteLine(Session.Language.EnterDate);

            reservationDate = FindNextOpenDate(DateTime.Today.AddDays(1), res.Guests.Count); // default

            while (true)
            {
                string input = ReadLine(show: true);

                if (input == "") // User has confirmed the date
                {
                    break;
                }
                else if (input == "1") // User pressed enter; suggest a date
                {
                    reservationDate = FindNextOpenDate(reservationDate, res.Guests.Count);
                    Console.WriteLine(string.Format(Session.Language.ConfirmSuggestedDate, reservationDate.ToShortDateString()));
                }
                else if (DateTime.TryParse(input, out reservationDate)) // Check if Date is valid
                {
                    var isDateAvailable = IsDateAvailable(reservationDate, res.Guests.Count);

                    if (isDateAvailable.Item1) // Date is valid and available, so continue..
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine(isDateAvailable.Item2); // Prints Reason why date is not available
                    }
                }
                else
                {
                    Console.WriteLine(Session.Language.InvalidDate);
                }
            }

            ViewLayout(CreateSeatList(reservationDate, res.Guests.Count));
        }

        public void ViewLayout(List<int> seats)
        {
            Log("Show Layout");
            PreviousStep = AskForDate;
            Console.WriteLine("Where would you like to sit? (for row: choose between 1 and 12)");
            res.Row = Convert.ToInt32(Console.ReadLine());
            Console.ReadLine();
            Console.WriteLine("for column: choose between 1 and 7");
            res.Column = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Your seat is row: {res.Row}, column: {res.Column}");


            string fullRow = "############################";
            string emptyRow = "#                          #";

            res.SeatNumber = seats.Count;

            int maxRowPopulation = 24;
            int rowPopulation = 0;
            int currentColumns = 1;

            Console.Clear();
            Console.WriteLine(string.Format(Session.Language.NotifySeatNumber, res.SeatNumber));
            Console.WriteLine(fullRow);
            Console.WriteLine(emptyRow);
            Console.Write("#");

            for (int i = 0; i < seats.Count; i++)
            {
                string Seat = CreateSeat(seats[i]);
                Console.WriteLine(Seat[i]);
                if (rowPopulation + Seat.Length > maxRowPopulation)
                {
                    CompleteRow(rowPopulation);
                    Console.WriteLine(emptyRow);
                    Console.Write("#");
                    WriteSeat(Seat, i == seats.Count - 1);
                    rowPopulation = Seat.Length;
                    currentColumns++;
                }
                else
                {
                    WriteSeat(Seat, i == seats.Count - 1);
                    rowPopulation += Seat.Length;
                }
            }

            CompleteRow(rowPopulation);
            WriteMissingRows();
            Console.WriteLine(emptyRow);
            Console.WriteLine(fullRow);

            WaitForInput();

            void CompleteRow(int rowLength)
            {
                Console.Write(string.Concat(Enumerable.Repeat(" ", maxRowPopulation - rowLength + 2)) + "#\n");
            }

            void WriteMissingRows()
            {
                int requiredColumns = 3;

                string remainingRows = string.Concat(Enumerable.Repeat(emptyRow + "\n", (requiredColumns - currentColumns) * 2));

                Console.Write(remainingRows);
            }

            string CreateSeat(int guests)
            {
                if (guests == 0 || guests == 1)
                {
                    return "  []";
                }
                return "  [" + string.Concat(Enumerable.Repeat(".", guests - 2)) + "]";
            }

            void WriteSeat(string Seat, bool color)
            {
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }

                Console.Write(Seat);

                if (color)
                {
                    Console.ResetColor();
                }
            }
            ReservationSummary();
        }

        #endregion Guest Details
        public void ReservationSummary()
        {
            Log("Showing Summary");

            res.ReservationDate = reservationDate.ToShortDateString();
            res.HostId = Session.User.Code;
            res.DateOfCreation = DateTime.Today.ToShortDateString();
            res.ReservationId = Guid.NewGuid().ToString();

            Console.Clear();
            Console.WriteLine($"\n{Session.Language.ReservationDate} " + res.ReservationDate);
            Console.WriteLine($"{Session.Language.SeatNumber} " + res.SeatNumber);
            Console.WriteLine($"{Session.Language.DateOfCreation} " + res.DateOfCreation);

            Console.WriteLine(Session.Language.Guests);
            foreach (Guest guest in res.Guests)
            {
                Console.WriteLine($"  - {Session.Language.Name} {guest.Name}");
                Console.WriteLine($"    - Email: {guest.Email}");
                Console.WriteLine($"    - {Session.Language.MovieChoice} {guest.movieChoice}");
                Console.WriteLine();
                
            }
        }
        #region Helper Functions

        public static Tuple<bool, string> IsDateAvailable(DateTime date, int guestCount)
        {
            Menu.Log("Is Date Available");
            // Check if specified date has already passed
            if (date < DateTime.Today)
            {
                return Tuple.Create(false, Session.Language.DateIsUnavailable);
            }

            // Mondays are closed
            if (date.DayOfWeek == DayOfWeek.Monday)
            {
                return Tuple.Create(false, Session.Language.DateIsMonday);
            }

            // Check if date is at capacity
            List<Reservation> reservations = Reservations.FetchAll(date);
            const int maxGuests = 44;
            // amount of guests start at one because the host needs to be accounted for as well
            int guestsSum = 0;

            for (int i = 0; i < reservations.Count; i++)
            {
                guestsSum += reservations[i].Guests.Count;
            }

            bool isAtCapacity = guestsSum + guestCount > maxGuests;

            if (isAtCapacity)
            {
                return Tuple.Create(false, Session.Language.DateAtCapacity);
            }
            else
            {
                return Tuple.Create(true, "");
            }
        }

        static DateTime FindNextOpenDate(DateTime initDate, int guestCount)
        {
            Log("Finding Next Open Date");
            DateTime nextDay = DateTime.Today.AddDays(1);

            // Loop keeps adding 1 day until a date is found that's available for the user
            while (true)
            {
                if (IsDateAvailable(nextDay, guestCount).Item1)
                {
                    return nextDay;
                }
                else
                {
                    nextDay = nextDay.AddDays(1);
                }
            }
        }

        static List<int> CreateSeatList(DateTime date, int newSeat)
        {
            List<Reservation> reservations = Reservations.FetchAll(date);

            List<int> seats = new List<int>();

            foreach (Reservation reservation in reservations)
            {
                seats.Add(reservation.Guests.Count);
            }

            seats.Add(newSeat);

            return seats;
        }

        public void NoYesPrompt(Action onYes, string sentence)
        {
            string[] choices = Session.Language.NoYes.Split(' ');
            int choiceIndex = 0;

            while (true)
            {
                RenderChoices();

                ConsoleKeyInfo input = ReadKey();

                if (input.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    if (choiceIndex == 1)
                    {
                        onYes();
                    }
                    break;
                }
                else if (input.Key == ConsoleKey.LeftArrow && choiceIndex > 0)
                {
                    choiceIndex--;
                }
                else if (input.Key == ConsoleKey.RightArrow && choiceIndex < choices.Length - 1)
                {
                    choiceIndex++;
                }
            }

            void RenderChoices()
            {
                Console.Clear();
                Console.WriteLine(sentence);

                Console.Write("<- ");
                for (int i = 0; i < choices.Length; i++)
                {
                    Console.Write("|  ");

                    if (choiceIndex == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }

                    Console.Write($"{choices[i]}  ");

                    if (choiceIndex == i)
                    {
                        Console.ResetColor();
                    }
                }
                Console.Write("| ->\n\n");
            }
        }
        #endregion

        #region *Special* Email Confirmation
        public void SendConfirmationMail(Reservation reservation)
        {
            string htmlBody = File.ReadAllText(@"emailTemplates/reservationConfirmationMail.txt");

            htmlBody = htmlBody.Replace("**reservation_creation**", reservation.DateOfCreation);
            htmlBody = htmlBody.Replace("**reservation**", reservation.ReservationDate);
            htmlBody = htmlBody.Replace("**Seat**", reservation.SeatNumber.ToString());
            htmlBody = htmlBody.Replace("**amount_guests**", (reservation.Guests.Count).ToString());
            htmlBody = htmlBody.Replace("**reservation_id**", reservation.ReservationId);

            var emailList = new List<string>();
            emailList.Add(Session.User.Email);

            foreach (var x in reservation.Guests)
            {
                emailList.Add(x.Email);
            }

            MailSender.SendConfirmationEmail(htmlBody, emailList, Session.Language.EmailReservationConfirmation);
        }
        #endregion
    }
}
