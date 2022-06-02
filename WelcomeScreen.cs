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

        public WelcomeScreen()
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

                Display("Welcome, dear guest! (o^▽^o)");
                Display("Please press [ENTER] to continue...");

                input = Console.ReadKey();
            }
            while (input.Key != ConsoleKey.Enter);

            next.Show();
        }
    }
}

