using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhibliFlix;

namespace GhibliFlix
{
    internal class WelcomeScreen
    {
        private readonly Screen next;

        public WelcomeScreen_1()
        {
            next = new Menu_2();
            next.SetPrevious(this);
        }
        public override void Show()
        {
            Log("[Step 1]");

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();

                Display("Welcome, dear guest.");
                Display("Please press [ENTER] to continue...");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);

            next.Show();
        }
    }
}
