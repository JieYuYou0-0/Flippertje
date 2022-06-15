using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix.menus
{
    public class AdminMenu : Menu
    {
        public override void Init()
        {
            Console.Clear();
            Log("Chihiro opens the admin menu");
            OverviewMenu overviewMenu = new OverviewMenu();
            PreviousMenu = overviewMenu.Init;

            string adminChoice = ReadLine();
            if (adminChoice == "1")
            {
                Console.WriteLine(Session.Admin.Password);
            }
        }
    }
}
