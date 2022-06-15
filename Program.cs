using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GhibliFlix
{
    interface IManager // Interface is always public; access modifier
    {
        void Render(); // Visualization
        int Run();
    }

    class Program
    {
        // To track the user's input; sort of a log
        public struct Information
        {
            public MovieMenu ChosenFilm { get; set; }
            public Members Member { get; set; }
            public int[][]? ChosenSeats { get; set; }
            public string ChosenTime { get; set; }
            public string ChosenDate { get; set; }
            public string VerificationCode { get; set; }
            public string RegistrationEmail { get; set; }
            public string[] AddMovieInfo { get; set; }
        }

        public static Information information { get; set; } // Instance variable

        static void Main(string[] args)
        {
            information = new Information();
            GhibliManager newGhibli = new GhibliManager();
            newGhibli.Intro();
        }
    }

    public class Controller // Verzorgt het contact tussen het systeem en het scherm
    {
        public class Button : Component// Draws buttons on the screen
        {
            public string Title { get; init; }
            public int Index { get; init; }

            public Button(string title)
            {
                this.Title = title;

            }

            public override void Display(int current_index)
            {
                if (Index == current_index)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.WriteLine($" {Title} ");
                Console.ResetColor();

            }

            // Draws a row of buttons on the screen
            public static List<Button> CreateRow(string[] titles)
            {
                var ButtonRow = new List<Button>();

                int total_length = titles.Length - 1;

                foreach (string title in titles)
                {
                    total_length += title.Length + 2;
                }

                int x = ((Console.WindowWidth - total_length) / 2);

                for (int i = 0; i < titles.Length; i++)
                {
                    ButtonRow.Add(new Button(titles[i]));
                    x += (titles[i].Length + 2);
                }

                return ButtonRow;
            }
        }

        // Accepts user's input and displays it on the screen
        public class Textbox : Component
        {
            protected string Placeholder;
            public string Input = "";
            public int Index;
            protected int X;
            protected int Y;
            protected bool Hidden;

            protected List<char> allowed =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=_+`~{}[]:;'\"\\|<>,./?!@#$%^&*()"
                    .ToCharArray().ToList();

            public Textbox(string placeholder, int index)
            {
                Placeholder = placeholder;
                this.Index = index;
            }
            public virtual void AddLetter(char character)
            {
                if (allowed.Contains(character))
                {
                    Input += character;
                }
            }
            public void Backspace()
            {
                if (Input != "")
                {
                    Input = Input.Remove(Input.Length - 1, 1);
                }
            }
            // Displays textbox on the screen
            public override void Display(int current_index)
            {
                Placeholder = Placeholder.PadRight(20);

                if (Input.PadRight(20) == "                    ")
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.BackgroundColor = ConsoleColor.Gray;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    Console.SetCursorPosition(X, Y);
                    Console.WriteLine(Placeholder);


                }
                else
                {
                    if (Index == current_index)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    if (Hidden)
                    {
                        if (Input.Length < 20)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(new string('*', Input.Length).PadRight(20));
                        }
                        else
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(new string('*', Input.Length).Remove(0, Input.Length - 20));
                        }
                    }
                    else
                    {
                        if (Input.Length < 20)
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(Input.PadRight(20));
                        }
                        else
                        {
                            Console.SetCursorPosition(X, Y);
                            Console.WriteLine(Input.Remove(0, Input.Length - 20));
                        }
                    }
                }
                Console.ResetColor();
            }

        }
        public abstract class BaseScreen
        {
            public abstract int Run();
        }

        public abstract class Component
        {
            public abstract void Display(int current_index);
        }

    }
}