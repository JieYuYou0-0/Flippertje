using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class RegisterMenu : IManager
    {
        private int Index = 0;
        private List<Controller.Textbox> Credentials = new List<Controller.Textbox>();
        public RegisterMenu()
        {
            Credentials.Add(new Controller.Textbox("Firstname", 0));
            Credentials.Add(new Controller.Textbox("Lastname", 1));
            Credentials.Add(new Controller.Textbox("Email", 2));
            Credentials.Add(new Controller.Textbox("Password", 3));
            Credentials.Add(new Controller.Textbox("Confirm Password", 4));
            Credentials.Add(new Controller.Textbox("Creditcard", 5));
        }

        public void Render()
        {
            DrawTextBoxes();
            string bottomMessage = "ARROW KEYS/Tab - Chance box  |  ENTER - Finish  |  ESCAPE - Go back";
            Console.WriteLine(bottomMessage);
        }
        private void DrawTextBoxes()
        {
            foreach (Controller.Textbox Field in Credentials)
            {
                Field.Display(Index);
            }
        }

        public int Run()
        {
            Console.Clear();
            ConsoleKey keyPressed;
            Render();
            do
            {
                var info = Program.information;
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.Enter)
                {
                    if (Credentials[0].Input == "")
                    {
                        Console.WriteLine("Firstname empty, try again.");
                    }
                    else if (Credentials[1].Input == "")
                    {
                        Console.WriteLine("Lastname empty, try again.");
                    }
                    else if (Credentials[2].Input == "")
                    {
                        Console.WriteLine("Email empty, try again.");
                    }
                    else if (Credentials[3].Input == "")
                    {
                        Console.WriteLine("Password empty, try again.");
                    }
                    else if (Credentials[4].Input == "")
                    {
                        Console.WriteLine("Confirm password empty, try again.");
                    }
                    else if (Credentials[5].Input.Length < 10)
                    {
                        Console.WriteLine("Creditcard has less than 10 numbers, try again.");
                    }
                    else
                    {
                        if(MailSender.IsValidEmail(Credentials[2].Input)) && !CustomerDetails.EmailExists(Credentials[2].Input) && AccountManager.PasswordCheck(Credentials[3].Input, Credentials[4].Input))
                    }

                }
            } while (b);
        }
    }
}
