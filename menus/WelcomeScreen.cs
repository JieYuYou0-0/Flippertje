using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class WelcomeScreen : Controller.BaseScreen, IManager
    {
        private int Index;
        private string Message;
        private List<Controller.Button> Buttons;

        public WelcomeScreen(string message, int index) 
        {
            this.Message = message;
            this.Index = index;
            string[] buttonTitles = { "Choose Movie", "Login", "Register", "Admin"};
            this.Buttons = Controller.Button.CreateRow(buttonTitles);
        }

        public void Render() // Visualizations on the screen
        {
            DrawButtons();
            string bottomMessage = "ARROW KEYS - select options  |  ENTER - Confirm  |  ESCAPE - Exit";
            Console.WriteLine(bottomMessage);

        }

        private void DrawButtons()
        {
            foreach (Controller.Button Button in Buttons)
            {
                Button.Display(Index);
            }
        }

        public override int Run()
        {
            Console.Clear();
            Render();
            ConsoleKey keyPressed;

            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.RightArrow)
                {
                    Index++;
                    if (Index > Buttons.Count - 1)
                    {
                        Index = 0;
                    }

                }
                if (keyPressed == ConsoleKey.LeftArrow)
                {
                    Index--;
                    if (Index < 0)
                    {
                        Index = Buttons.Count - 1;
                    }
                }
                DrawButtons();

            } while (keyPressed != ConsoleKey.Enter);

            return this.Index;
        }
    }
}


