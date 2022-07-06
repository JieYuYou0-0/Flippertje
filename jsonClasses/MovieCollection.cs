using System;

namespace GhibliFlix
{
    public class MovieCollection
    {
        public Movie Movie_1 { get; set; }
        public Movie Movie_2 { get; set; }
        public Movie Movie_3 { get; set; }
        public Movie Movie_4 { get; set; }
        public Movie Movie_5 { get; set; }
        public Movie Movie_6 { get; set; }
        public Movie Movie_7 { get; set; }
        public Movie Movie_8 { get; set; }

        #region movies

        //public abstract class MovieTraits
        //{

        //}

        public abstract class Movie
        {
            public Movie Movie_1 { get; set; }
            public Movie Movie_2 { get; set; }
            public Movie Movie_3 { get; set; }
            public Movie Movie_4 { get; set; }
            public Movie Movie_5 { get; set; }
            public Movie Movie_6 { get; set; }
            public Movie Movie_7 { get; set; }
            public Movie Movie_8 { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public string Description { get; set; }
            public string Duration { get; set; }

        }
        public class Movie1 : Movie
        {
            public string Title = "My Neighbor Totoro";
            public double Price = 12.00;
            public string Description = "When Satsuki and her sister Mei move with their father to a new home in the countryside, they find country life is not as simple as it seems.\n" +
                                        "They soon discover that the house and nearby woods are full of strange and delightful creatures, including a gigantic but gentle forest spirit called Totoro, who can only be seen by children.\n" +
                                        "Totoro and his friends introduce the girls to a series of adventures, including a ride aboard the extraordinary Cat Bus.";

            public int Duration = 120;

        }

        public class Movie2 : Movie
        {
            public string Title = "Howl's Moving Castle";
            public double Price = 12.00;
            public string Description = "Sophie, a quiet girl working in a hat shop, finds her life thrown into turmoil when she is literally swept off her feet by a handsome but mysterious wizard named Howl.\n" +
                                        "The vain and vengeful Witch of the Waste, jealous of their friendship, puts a curse on Sophie and turns her into a 90-year-old woman.\n" +
                                        "On a quest to break the spell, Sophie climbs aboard Howl’s magnificent moving castle and into a new life of wonder and adventure.\n" +
                                        "But as the true power of Howl’s wizardry is revealed, Sophie finds herself fighting to protect them both from a dangerous war of sorcery that threatens their world.";

            public int Duration = 100;
        }

        public class Movie3 : Movie
        {
            public string Title = "Princess Mononoke";
            public double Price = 15.00;
            public string Description = "The story follows a young Emishi prince named Ashitaka, and his involvement in a struggle between the gods of a forest and the humans who consume its resources.";
            public int Duration = 120;
        }

        public class Movie4 : Movie
        {
            public string Title = "Kiki's Delivery Service";
            public double Price = 16.00;
            public string Description = "It is a tradition for all young witches to leave their families on the night of a full moon and fly off into the wide world to learn their craft.\n" +
                                        "When that night comes for Kiki, she embarks on her new journey with her sarcastic black cat, Jiji, landing the next morning in a seaside village, where her unique skills make her an instant sensation.";
            public int Duration = 100;
        }

        public class Movie5 : Movie
        {
            public string Title = "Ponyo";
            public double Price = 20.00;
            public string Description = "When Sosuke, a young boy who lives on a clifftop overlooking the sea, rescues a stranded goldfish named Ponyo, he discovers more than he bargained for.\n" +
                                        "Ponyo is a curious energetic young creature who yearns to be human, but even as she causes chaos around the house, her father, a powerful sorcerer, schemes to return Ponyo to the sea.";
            public int Duration = 120;
        }
        public class Movie6 : Movie
        {
            public string Title = "Spirited Away";
            public double Price = 20.00;
            public string Description = "Chihiro's family is moving to a new house, but when they stop on the way to explore an abandoned village, her parents undergo a mysterious transformation and Chihiro is whisked into a world of fantastic spirits ruled over by the soceress Yubaba.\n" +
                                        "Put to work in a magical bathhouse for spirits and demons, Chihiro must use all her wits to survive in this strange new place, find a way to free her parents and return to the normal world.";
            public int Duration = 100;
        }
        public class Movie7 : Movie
        {
            public string Title = "The Cat Returns";
            public double Price = 16.00;
            public string Description = "Haru is walking home after a dreary day of school when she spies a cat with a small gift box in its mouth crossing a busy street, and she jumps in front of traffic to save the cat from an oncoming truck.\n" +
                                        "To her amazement, the cat gets up on its hind legs, brushes itself off, and thanks her very politely.\n" +
                                        "But things take an even stranger turn when later that night, the King of Cats shows up at her doorstep in a feline motorcade.\n" +
                                        "He showers Haru with gifts, and decrees that she shall marry the Prince and come live in the Kingdom of Cats!";
            public int Duration = 120;
        }
        public class Movie8 : Movie
        {
            public string Title = "The Wind Rises";
            public double Price = 18.00;
            public string Description = "Jiro dreams of flying and designing beautiful airplanes, inspired by the famous Italian aeronautical designer Caproni.\n" +
                                        "Nearsighted and unable to be a pilot, he becomes one of the world’s most accomplished airplane designers, experiencing key historical events in an epic tale of love, perseverance and the challenges of living and making choices in a turbulent world.";
            public int Duration = 100;
        }

        #endregion

    }
}