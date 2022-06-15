using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class MovieMenu : Menu
    {
        public string title;
        public double price;

        public MovieMenu()
        {

        }

        public void GetMovieOverview()
        {
            Menu.Log("Kiki opens Movie menu");
            Menu menu = new Menu();
            PreviousStep = menu.Init;
            string settingsJson = File.ReadAllText("json_files/movies.json");

        }
        public string[] GetTitles()
        {
            string[] titles = new string[]
            {
                "My Neighbor Totoro",
                "Howl's Moving Castle",
                "Princess Mononoke",
                "Kiki's Delivery Service",
                "Ponyo",
                "Spirited Away",
                "The Cat Returns",
                "The Wind Rises"
            };
            foreach (string title in titles)
            {
                Random rnd = new Random();
                rnd.Next(titles.Length);
            }

            return titles;
        }

        public double[] GetPrices()
        {
            double[] prices = new double[8];
            for (double i = 0.00; i < prices.Length; i++)
            {
                Random rnd = new Random();
                rnd.Next(10, 20);
            }

            return prices;
        }
        public Tuple<string, double>[] GetMovieCollection()
        {
            Tuple<string, double>[] movieCollection = new Tuple<string, double>[8];
            for (int i = 0; i < movieCollection.Length; i++)
            {
                Tuple.Create(this.title, this.price);
            }
            return movieCollection;
        }
    }
}
