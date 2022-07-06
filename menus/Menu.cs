using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public abstract class Menu
    {
        #region Properties
        public Action PreviousStep { private get; set; }

        public Action PreviousMenu { private get; set; }

        private readonly List<Tuple<Action, ConsoleKey, string>> commands = new List<Tuple<Action, ConsoleKey, string>>();

        #endregion Properties

        #region Menu
        public virtual void Init()
        {
            throw new NotImplementedException("Not implemented");
        }

        public void AddMenuOption(Action function, ConsoleKey keyPress, string display)
        {
            commands.Add(Tuple.Create(function, keyPress, display));
        }

        public void ShowMenu()
        {
            WriteMenu();
            ReadOptionInput();
        }

        private void WriteMenu()
        {
            Console.WriteLine();
            foreach (var command in commands)
            {
                if (command.Item3 != "")
                {
                    Console.WriteLine(command.Item3);
                }
            }
            Console.WriteLine();
        }

        public void ReadOptionInput()
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
        #endregion Menu

        #region Escape Commands
        private void ExecuteCtrlQCommand()
        {
            Menu.Log("Restart Flow");
            Console.Clear();
            Init();
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

        private void ExecuteCtrlSCommand()
        {
            Menu.Log("Close App");
        }

        private bool DetectBackCommand(ConsoleKeyInfo input)
        {
            if ((input.Modifiers & ConsoleModifiers.Control) != 0)
            {
                if (input.Key == ConsoleKey.Q)
                {
                    ExecuteCtrlQCommand();
                    return true;
                }
                else if (input.Key == ConsoleKey.S)
                {
                    ExecuteCtrlSCommand();
                    return true;
                }

            }
            else if (input.Key == ConsoleKey.Escape)
            {
                ExecuteEscCommand();
                return true;
            }
            return false;
        }
        #endregion Escape Commands

        #region Read
        internal ConsoleKeyInfo ReadKey()
        {
            ConsoleKeyInfo input = Console.ReadKey(intercept: true);
            if (DetectBackCommand(input))
            {
                return new ConsoleKeyInfo((char)ConsoleKey.Escape, ConsoleKey.Escape, false, false, false);
            }
            return input;
        }

        internal string ReadLine(bool show = false)
        {
            ConsoleKeyInfo input;
            StringBuilder builder = new StringBuilder();

            while (true)
            {
                input = Console.ReadKey(intercept: true);

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

            // Dont clear line when show is set to true
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

        #region WaitForInput Methods
        internal void ReadBackInput()
        {
            Console.WriteLine("\n" + Session.Language.Continue);
            Console.ReadKey();
            ExecuteCtrlQCommand();
        }

        internal void GotoPreviousMenu()
        {
            Console.WriteLine("\n" + Session.Language.Continue);
            Console.ReadKey();
            PreviousMenu();
        }

        internal void WaitForInput()
        {
            Console.WriteLine("\n" + Session.Language.Continue);
            var input = ReadKey();

            if (input.Key == ConsoleKey.Escape)
            {
                return;
            }
        }

        internal void ClearCurrentLine()
        {
            var currentLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLine);
        }
        #endregion WaitForInput Methods

        #endregion Read
        internal static string BoolToLanguage(bool condition)
        {
            string[] options = Session.Language.NoYes.Split(' ');
            return options[Convert.ToInt32(condition)];
        }

        internal static void Log(string message)
        {
            DateTime now = DateTime.Now;
            string sResultaat = $"[{now.ToString("yyyy/MM/dd hh:mm:ss")}]\t[{message}]\n";
            File.AppendAllText("chatlog.txt", sResultaat);
        }

        internal static void ClearLog()
        {
            File.WriteAllText("chatlog.txt", String.Empty);
            Menu.Log("Log Cleared, Started new Session");
        }
    }
}