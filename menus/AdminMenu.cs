using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;


namespace GhibliFlix
{
    class AdminMenu : Menu
    {
        private MovieCollection.Movie movie1 = new MovieCollection.Movie1();
        private MovieCollection.Movie movie2 = new MovieCollection.Movie2();
        private MovieCollection.Movie movie3 = new MovieCollection.Movie3();
        private MovieCollection.Movie movie4 = new MovieCollection.Movie4();
        private MovieCollection.Movie movie5 = new MovieCollection.Movie5();
        private MovieCollection.Movie movie6 = new MovieCollection.Movie6();
        private MovieCollection.Movie movie7 = new MovieCollection.Movie7();
        private MovieCollection.Movie movie8 = new MovieCollection.Movie8();

        public override void Init()
        {
            Console.Clear();
            Log("Admin Menu Opened");
            GuestMenu guestmenu = new GuestMenu();
            PreviousMenu = guestmenu.Init;

            Console.WriteLine(Session.Language.AdminMenuChoices);
            //Console.WriteLine("[1] View movie on date");
            Console.WriteLine("[1] Go to change movies menu");
            Console.WriteLine("[2] Go to movie Overview menu\n");

            var AdminChoice = ReadLine();

            //if (AdminChoice == "1")
            //{
            //    // View movie on date
            //    Console.WriteLine(Session.Language.AdminMenu);
            //    string date = ReadLine();
            //    ViewMovieOnDate(date);
            //}
            if (AdminChoice == "1")
            {
                // Change movie menu
                AdminMenu Adminmenu = new AdminMenu();
                Adminmenu.ChangeMovies();
            }
            else if (AdminChoice == "2")
            {
                // Movie overview
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.MovieOverview();
                Console.WriteLine("Do you want to change a movie? Please choose Y or N.");
                var answer = ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    adminMenu.ChangeMovies();
                }
                else if (answer == "n" || answer == "N")
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine(Session.Language.InvalidOption);
                ReadBackInput();
            }
        }

        private void MovieOverview()
        {
            Console.Clear();
            Console.WriteLine("Movie1 " +
                              "Title: My Neighbor Totoro\n\n" +
                              "Description: \nWhen Satsuki and her sister Mei move with their father to a new home in the countryside, they find country life is not as simple as it seems." +
                              "They soon discover that the house and nearby woods are full of strange and delightful creatures, including a gigantic but gentle forest spirit called Totoro, who can only be seen by children." +
                              "Totoro and his friends introduce the girls to a series of adventures, including a ride aboard the extraordinary Cat Bus.\n\n" +
                              "");
            Console.WriteLine($"Movie2: Howl's Moving Castle");
            Console.WriteLine($"Movie3: Princess Mononoke");
            Console.WriteLine($"Movie4: Kiki's Delivery Service");
            Console.WriteLine($"Movie5: Ponyo");
            Console.WriteLine($"Movie6: Spirited Away");
            Console.WriteLine($"Movie7: The Cat Returns");
            Console.WriteLine($"Movie8: The Wind Rises");

        }
        private void ChangeMovies()
        {
            Log("Admin ChangeMovies method");

            string moviesJson = File.ReadAllText(@"jsonFiles/movies.json");
            MovieCollection movies = JsonSerializer.Deserialize<MovieCollection>(moviesJson);

            Console.Clear();
            Console.WriteLine(Session.Language.ChangeMenu);

            PreviousMenu = Init;
            Console.WriteLine("[1] Change Movie1");
            Console.WriteLine("[2] Change Movie2");
            Console.WriteLine("[3] Change Movie3");
            Console.WriteLine("[4] Change Movie4");
            Console.WriteLine("[5] Change Movie5");
            Console.WriteLine("[6] Change Movie6");
            Console.WriteLine("[7] Change Movie7");
            Console.WriteLine("[8] Change Movie8\n");

            string AdminKeuze = ReadLine();
            PreviousMenu = ChangeMovies;

            if (AdminKeuze == "1")
            {
                // Movie1 aanpassen
                Log("Change Movie1 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie1);
                Console.WriteLine("[A] Change title of Movie1");
                Console.WriteLine("[B] Change description of Movie1");
                Console.WriteLine("[C] Change price of Movie1");
                Console.WriteLine("[D] Change duration of Movie1\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie1 has been changed to: {title}.");
                    this.movie1.Title = title;
                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie1 has been changed to: {description}.");
                    this.movie1.Description = description;
                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    var price = ReadLine();
                    Console.WriteLine(price);
                    Console.WriteLine($"The price of Movie1 has been changed to: {price} Euros.");
                    this.movie1.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine(duration);
                    Console.WriteLine($"The duration of Movie1 has been changed to: {duration} minutes.");
                    this.movie1.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie1Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "2")
            {
                // Movie2 menu aanpassen
                Log("Change Movie2 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie2);
                Console.WriteLine("[A] Change title of Movie2");
                Console.WriteLine("[B] Change description of Movie2");
                Console.WriteLine("[C] Change price of Movie2");
                Console.WriteLine("[D] Change duration of Movie2\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie2 has been changed to: {title}.");
                    this.movie2.Title = title;
                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie2 has been changed to: {description}.");
                    this.movie2.Description = description;
                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie2 has been changed to: {price} Euros.");
                    this.movie2.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie2 has been changed to: {duration} minutes.");
                    this.movie2.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);
                Console.WriteLine(Session.Language.Movie2Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "3")
            {
                // movie3 menu aanpassen
                Log("Change Movie3 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie3);
                Console.WriteLine("[A] Change title of Movie3");
                Console.WriteLine("[B] Change description of Movie3");
                Console.WriteLine("[C] Change price of Movie3");
                Console.WriteLine("[D] Change duration of Movie3\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie3 has been changed to: {title}.");
                    this.movie3.Title = title;

                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie3 has been changed to: {description}.");
                    this.movie3.Description = description;

                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie3 has been changed to: {price} Euros.");
                    this.movie3.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie3 has been changed to: {duration} minutes.");
                    this.movie3.Duration = duration;

                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);
                Console.WriteLine(Session.Language.Movie3Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "4")
            {
                // Movie4 menu aanpassen
                Log("Change Movie4 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie4);
                Console.WriteLine("[A] Change title of Movie4");
                Console.WriteLine("[B] Change description of Movie4");
                Console.WriteLine("[C] Change price of Movie4");
                Console.WriteLine("[D] Change duration of Movie4\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie4 has been changed to: {title}.");
                    this.movie4.Title = title;
                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie4 has been changed to: {description}.");
                    this.movie4.Description = description;
                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie4 has been changed to: {price} Euros.");
                    this.movie4.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie4 has been changed to: {duration} minutes.");
                    this.movie4.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie4Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "5")
            {
                // Movie5 menu aanpassen
                Log("Change Movie5 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie5);
                Console.WriteLine("[A] Change title of Movie5");
                Console.WriteLine("[B] Change description of Movie5");
                Console.WriteLine("[C] Change price of Movie5");
                Console.WriteLine("[D] Change duration of Movie5\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie5 has been changed to: {title}.");
                    this.movie5.Title = title;
                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"the description of Movie5 has been changed to: {description}.");
                    this.movie5.Description = description;
                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie5 has been changed to: {price} Euros.");
                    this.movie5.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie5 has been changed to: {duration} minutes.");
                    this.movie5.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie5Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "6")
            {
                // Movie6 menu aanpassen
                Log("Change Movie6 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie6);
                Console.WriteLine("[A] Change title of Movie6");
                Console.WriteLine("[B] Change description of Movie6");
                Console.WriteLine("[C] Change price of Movie6");
                Console.WriteLine("[D] Change duration of Movie6\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie6 has been changed to: {title}.");
                    this.movie6.Title = title;

                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie6 has been changed to: {description}.");
                    this.movie6.Description = description;

                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie6 has been changed to: {price} Euros.");
                    this.movie6.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie6 has been changed to: {duration} minutes.");
                    this.movie6.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie6Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "7")
            {
                // Movie7 menu aanpassen
                Log("Change Movie7 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie7);
                Console.WriteLine("[A] Change title of Movie7");
                Console.WriteLine("[B] Change description of Movie7");
                Console.WriteLine("[C] Change price of Movie7");
                Console.WriteLine("[D] Change duration of Movie7\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie7 has been changed to: {title}.");
                    this.movie7.Title = title;
                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie7 has been changed to: {description}.");
                    this.movie7.Description = description;

                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie7 has been changed to: {price} Euros.");
                    this.movie7.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie7 has been changed to: {duration} minutes.");
                    this.movie7.Duration = duration;
                }
                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie7Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else if (AdminKeuze == "8")
            {
                // Movie8 menu aanpassen
                Log("Change Movie8 menu");
                Console.Clear();
                Console.WriteLine(Session.Language.ChangeMovie8);
                Console.WriteLine("[A] Change title of Movie8");
                Console.WriteLine("[B] Change description of Movie8");
                Console.WriteLine("[C] Change price of Movie8");
                Console.WriteLine("[D] Change duration of Movie8\n");
                ConsoleKeyInfo adminChoice = ReadKey();

                if (adminChoice.Key == ConsoleKey.A)
                {
                    Console.WriteLine(Session.Language.ChangeTitle);
                    string title = ReadLine();
                    Console.WriteLine($"The title of Movie8 has been changed to: {title}.");
                    this.movie8.Title = title;

                }

                else if (adminChoice.Key == ConsoleKey.B)
                {
                    Console.WriteLine(Session.Language.ChangeDescription);
                    string description = ReadLine();
                    Console.WriteLine($"The description of Movie8 has been changed to: {description}.");
                    this.movie8.Description = description;

                }

                else if (adminChoice.Key == ConsoleKey.C)
                {
                    Console.WriteLine(Session.Language.ChangePrice);
                    string price = ReadLine();
                    Console.WriteLine($"The price of Movie8 has been changed to: {price} Euros.");
                    this.movie8.Price = Convert.ToDouble(price);
                }

                else if (adminChoice.Key == ConsoleKey.D)
                {
                    Console.WriteLine(Session.Language.ChangeDuration);
                    string duration = ReadLine();
                    Console.WriteLine($"The duration of Movie8 has been changed to: {duration} minutes.");
                    this.movie8.Duration = duration;
                }

                // Wijzigingen naar movies.json schrijven
                string NewmoviesJson = JsonSerializer.Serialize(movies);
                File.WriteAllText(@"jsonFiles/movies.json", NewmoviesJson);

                Console.WriteLine(Session.Language.Movie8Changed);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
            else
            {
                //Ongeldige invoer
                Log("Unknown input for ChangeMenu");
                Console.WriteLine(Session.Language.InvalidOption);

                PreviousStep = ChangeMovies;
                ReadBackInput();
            }
        }
    }
}
