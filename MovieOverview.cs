using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;


namespace GhibliFlix
{
    internal class MovieOverview
    {
        private string title;
        private double price;

        public Movies()
        {

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
                Tuple.Create(title, price);
            }
            return movieCollection;
        }
    }
}

