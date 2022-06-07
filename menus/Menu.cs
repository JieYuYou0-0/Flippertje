using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class Menu
    {
        internal Action PreviousStep { get; set; }
        internal Action PreviousMenu { get; set; }

        private readonly List<Tuple<Action, ConsoleKey>> commands = new List<Tuple<Action, ConsoleKey>>();

        internal virtual void Init()
        {
            throw new NotImplementedException("Not implemented");
        }

        internal void AddMenuOption(Action function, ConsoleKey keyPress)
        {
            commands.Add(Tuple.Create(function, keyPress));
        }

        internal void ShowMenu()
        {
            //WriteMenu();
            ReadOptionInput();
        }

        //private void WriteMenu()
        //{
        //    //Console.WriteLine();
        //    foreach (var command in commands)
        //    {
        //        if (command.Item3 != "")
        //        {
        //            Console.WriteLine(command.Item3);
        //        }
        //    }
        //    //Console.WriteLine();
        //}
        internal void ReadOptionInput()
        {
            while (true)
            {
                ConsoleKeyInfo input = ReadKey();

                var command = commands.FirstOrDefault(command => input.Key == command.Item2);
                if (command != null)
                {
                    command.Item1();
                    break;
                }
            }
        }

        private void ExecuteEscCommand()
        {
            if (PreviousStep != null)
            {
                Log("Previous Step");
                ClearCurrentLine();
                PreviousStep();
            }
            else if (PreviousMenu != null)
            {
                Log("Previous Menu");
                PreviousMenu();
            }
        }
        private bool DetectBackCommand(ConsoleKeyInfo input)
        {
            if (input.Key == ConsoleKey.Escape)
            {
                ExecuteEscCommand();
                return true;
            }
            return false;
        }
        internal ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo input = Console.ReadKey(true);
            if (DetectBackCommand(input))
            {
                return new ConsoleKeyInfo((char)ConsoleKey.Escape, ConsoleKey.Escape, false, false, false);
            }
            return input;
        }
        internal string ReadLine(bool show = false)
        {
            ConsoleKeyInfo input;

            // Stringbuilder class for creating a new text
            StringBuilder builder = new StringBuilder();

            while (true)
            {
                input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (DetectBackCommand(input))
                {
                    return null;
                }
                else if (input.Key == ConsoleKey.Backspace && builder.Length > 0)
                {
                    builder.Remove(builder.Length - 1, 1);
                    ClearCurrentLine();
                    Console.Write(builder.ToString());
                }
                else
                {
                    builder.Append(input.KeyChar);
                    Console.Write(input.KeyChar);
                }
            }

            // Dont clear line when show is true
            if (show == true)
            {
                Console.WriteLine();
            }
            else
            {
                ClearCurrentLine();
            }
            return builder.ToString();
        }

        internal void GotoPreviousMenu()
        {
            Console.ReadKey();
            PreviousMenu();
        }

        internal void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }

        internal static void Log(string message)
        {
            DateTime now = DateTime.Now;
            string result = $"[{now.ToString("yyyy/MM/dd hh:mm:ss")}]\t[{message}]\n";
            File.AppendAllText("json_files/chatlog.txt", result);
        }

        internal static void ClearLog()
        {
            File.WriteAllText("chatlog.txt", String.Empty);
            Menu.Log("Log Cleared, Started new Session");
        }
    }
}
