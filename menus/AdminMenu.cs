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
            Console.WriteLine("[1] Go to change movies menu");
            Console.WriteLine("[2] Go to movie Overview menu\n");

            var AdminChoice = ReadLine();

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
                Console.WriteLine("Do you want to change a movie? Please choose Y or y.");
                var answer = ReadLine();
                if (answer == "y" || answer == "Y")
                {
                    adminMenu.ChangeMovies();
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
            Console.WriteLine($"Movie1\n" +
                              $"Title: My Neighbor Totoro\n" +
                              $"Description:\n" +
                              $"When Satsuki and her sister Mei move with their father to a new home in the countryside, they find country life is not as simple as it seems." +
                              $"They soon discover that the house and nearby woods are full of strange and delightful creatures, including a gigantic but gentle forest spirit called Totoro, who can only be seen by children." +
                              $"Totoro and his friends introduce the girls to a series of adventures, including a ride aboard the extraordinary Cat Bus.\n\n" +
                              $"Price: 12,00 euros\n" +
                              $"Duration: 120 minutes\n\n");

            Console.WriteLine($"Movie2\n" +
                              $"Title: Howl's Moving Castle\n" +
                              $"Description:\n" +
                              $"Sophie, a quiet girl working in a hat shop, finds her life thrown into turmoil when she is literally swept off her feet by a handsome but mysterious wizard named Howl." +
                              $"The vain and vengeful Witch of the Waste, jealous of their friendship, puts a curse on Sophie and turns her into a 90 - year - old woman. " +
                              $"On a quest to break the spell, Sophie climbs aboard Howl’s magnificent moving castle and into a new life of wonder and adventure. " +
                              $"But as the true power of Howl’s wizardry is revealed, Sophie finds herself fighting to protect them both from a dangerous war of sorcery that threatens their world.\n\n" +
                              $"Price: 13,00 euros\n" +
                              $"Duration: 100 minutes\n\n");

            Console.WriteLine($"Movie3\n" +
                              $"Title: Princess Mononoke\n" +
                              $"Description:\n" +
                              $"The story follows a young Emishi prince named Ashitaka, and his involvement in a struggle between the gods of a forest and the humans who consume its resources.\n\n" +
                              $"Price: 17,00 euros\n" +
                              $"Duration: 120 minutes\n\n");

            Console.WriteLine($"Movie5\n" +
                              $"Title: Kiki's Delivery Service\n" +
                              $"Description:\n " +
                              $"It is a tradition for all young witches to leave their families on the night of a full moon and fly off into the wide world to learn their craft." +
                              $"When that night comes for Kiki, she embarks on her new journey with her sarcastic black cat, Jiji, landing the next morning in a seaside village, where her unique skills make her an instant sensation.\n\n" +
                              $"Price: 16,00 euros\n" +
                              $"Duration: 100 minutes\n\n");

            Console.WriteLine($"Movie5\n" +
                              $"Title: Ponyo\n" +
                              $"Description:\n " +
                              $"When Sosuke, a young boy who lives on a clifftop overlooking the sea, rescues a stranded goldfish named Ponyo, he discovers more than he bargained for." +
                              $"Ponyo is a curious energetic young creature who yearns to be human, but even as she causes chaos around the house, her father, a powerful sorcerer, schemes to return Ponyo to the sea.\n\n" +
                              $"Price: 15,00 euros\n" +
                              $"Duration: 120 minutes\n\n");

            Console.WriteLine($"Movie6\n" +
                              $"Title: Spirited Away\n" +
                              $"Description:\n " +
                              $"Chihiro's family is moving to a new house, but when they stop on the way to explore an abandoned village, her parents undergo a mysterious transformation and Chihiro is whisked into a world of fantastic spirits ruled over by the soceress Yubaba." +
                              $"Put to work in a magical bathhouse for spirits and demons, Chihiro must use all her wits to survive in this strange new place, find a way to free her parents and return to the normal world.\n\n" +
                              $"Price: 11,00 euros\n" +
                              $"Duration: 100 minutes\n\n");

            Console.WriteLine($"Movie7\n" +
                              $"Title: The Cat Returns\n" +
                              $"Description:\n " +
                              $"Haru is walking home after a dreary day of school when she spies a cat with a small gift box in its mouth crossing a busy street, and she jumps in front of traffic to save the cat from an oncoming truck." +
                              $"To her amazement, the cat gets up on its hind legs, brushes itself off, and thanks her very politely." +
                              $"But things take an even stranger turn when later that night, the King of Cats shows up at her doorstep in a feline motorcade." +
                              $"He showers Haru with gifts, and decrees that she shall marry the Prince and come live in the Kingdom of Cats!\n\n" +
                              $"Price: 1.,00 euros\n" +
                              $"Duration: 120 minutes\n\n");

            Console.WriteLine($"Movie8\n" +
                              $"Title: The Wind Rises\n" +
                              $"Description:\n " +
                              $"Jiro dreams of flying and designing beautiful airplanes, inspired by the famous Italian aeronautical designer Caproni." +
                              $"Nearsighted and unable to be a pilot, he becomes one of the world’s most accomplished airplane designers, experiencing key historical events in an epic tale of love, perseverance and the challenges of living and making choices in a turbulent world.\n\n" +
                              $"Price: 9,00 euros\n" +
                              $"Duration: 100 minutes\n\n");

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
