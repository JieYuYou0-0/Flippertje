using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhibliFlix;
using GhibliFlix.menus;

namespace GhibliFlix
{
    internal class WelcomeScreen : Menu
    {
        internal MenuOverview menuOverview;
        internal Settings settingsMenu;
        private readonly Settings settingsJson;
        internal WelcomeScreen()
        {
        }
        internal override void Init()
        {
            Log("[Step 1]");

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();

                Console.WriteLine("Welcome, dear guest! (o^V^o)");
                Console.WriteLine("Please press [ENTER] to continue...");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);


        }

        private void OpenMenuOverview()
        {
            menuOverview = new MenuOverview();
            menuOverview.Init();
            // Volgende menu moet zijn menuOverview.
        }
    }
}