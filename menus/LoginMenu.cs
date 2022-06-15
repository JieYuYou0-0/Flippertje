using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class LoginMenu : Menu
    {
        private readonly MovieMenu chooseMovie;
        private readonly MovieMenu viewReservation;
        private readonly MovieMenu logOut;
        public LoginMenu()
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

    }
}
