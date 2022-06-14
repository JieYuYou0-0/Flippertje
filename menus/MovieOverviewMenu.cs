using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class MovieOverviewMenu : Menu
    {
        internal string title;
        internal double price;

        internal MovieOverviewMenu()
        {

        }

        internal void GetMovieOverview()
        {
            Menu.Log("Kiki opens MovieOverview");
            Menu menu = new Menu();
            PreviousStep = menu.Init;
            string settingsJson = File.ReadAllText("json_files/movies.json");

        }
        internal string[] GetTitles()
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

        internal double[] GetPrices()
        {
            double[] prices = new double[8];
            for (double i = 0.00; i < prices.Length; i++)
            {
                Random rnd = new Random();
                rnd.Next(10, 20);
            }

            return prices;
        }
        internal Tuple<string, double>[] GetMovieCollection()
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
