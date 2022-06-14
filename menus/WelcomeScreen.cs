using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class WelcomeScreen : Menu
    {
        
        internal WelcomeScreen()
        {
        }
        internal override void Init()
        {
            Log("[GhibliFlix welcomes the guest! :D]");
            ConsoleKeyInfo input;

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome, dear guest! (o^▽^o)");
                Console.WriteLine("Please press [ENTER] to continue...");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);
            ShowMenu();
            OpenOverview();

        }

        private void OpenOverview()
        {
            Overview overview = new Overview();
            overview.Init();
        }
    }
}

