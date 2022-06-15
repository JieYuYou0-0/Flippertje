using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhibliFlix.menus;

namespace GhibliFlix
{
    public class OverviewMenu : Menu // Overzichtsmenu voor het inloggen
    {
        private readonly MovieMenu movieOverviewMenu;
        private readonly MembershipMenu membershipMenu;
        private readonly AdminMenu adminMenu;
        private const string adminCode = "admin";

        public OverviewMenu()
        {
            AddMenuOption(MembershipLogin, ConsoleKey.D1, "Login");


            this.membershipMenu = new MembershipMenu();
            this.adminMenu = new AdminMenu();

            this.membershipMenu.PreviousStep = Init;
            this.adminMenu.PreviousStep = Init;
        }

        public void MembershipLogin()
        {
            LoginMenu newLogin = new LoginMenu();
            newLogin.
        }
       
    }
}
