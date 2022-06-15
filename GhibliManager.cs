using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GhibliFlix.menus;

namespace GhibliFlix
{
    public class GhibliManager
    {
        public int MainMenu_LastIndex = 0;
        public void Run()
        {
           RunWelcomeScreen();
        }

        private void RunWelcomeScreen()
        {
            string welcomeMessage = $"Welcome, dear guest! (o^v^o)\n" +
                                    $"Please press [ENTER] to continue~\n";
            string[] overviewMenu = { "Choose Film", "Login", "Register", "Admin"};
            WelcomeScreen welcomeScreen = new WelcomeScreen();
            int selectedIndex = welcomeScreen.Run();
            this.MainMenu_LastIndex = selectedIndex;
            switch (selectedIndex)
            {
                case 0:
                    MovieOverviewMenu();
                    break;
                case 1:
                    LoginMenu();
                    break;
                case 2:
                    RegisterMenu();
                    break;
                case 3:
                    AdminMenu();
                    break;
            }
        }

        private void MovieOverviewMenu()
        {
            MovieMenu movieOverview = new MovieMenu();
            movieOverview.Init();
        }

        private void LoginMenu()
        {
            LoginMenu login = new LoginMenu();
            login.Init();
        }

        private void RegisterMenu()
        {
            RegisterMenu register = new RegisterMenu();
            register.Init();
        }

        private void AdminMenu()
        {
            AdminMenu admin = new AdminMenu();
            admin.Init();
        }
    }
}
