using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class WelcomeScreen 
    {
        
        public WelcomeScreen()
        {
        }
        public override void Init()
        {
            Log("[GhibliFlix welcomes the guest! :D]");
            ConsoleKeyInfo input;

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome, dear guest! (o^v^o)");
                Console.WriteLine("Please press [ENTER] to continue...");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);
            ShowMenu();
            OpenOverviewMenu();

        }

        private void OpenOverviewMenu()
        {
        }
    }
}

