using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class SettingDate
    {
        internal ExploreMovies_4()
        {

        }

        internal DateTime GetDateInput()
        {
            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
            while (true)
            {
                Display("Set your date: ");
                string readFromUser = Console.ReadLine();
                DateTime scheduleDate;
                if (DateTime.TryParseExact(readFromUser, dateFormats, DateTimeFormatInfo.InvariantInfo,
                        DateTimeStyles.None, out scheduleDate) && scheduleDate > DateTime.Now &&
                    scheduleDate.Date != DateTime.Now.Date)
                {
                    Display("At what time are you planning to visit us?");
                    ConsoleKeyInfo input;
                    do
                    {
                        Display("You can choose: \n" +
                                "[1] 12:00\n" +
                                "[2] 15:00\n" +
                                "[3] 20:00");

                        input = Console.ReadKey();

                    } while (input.Key != ConsoleKey.D1 && input.Key != ConsoleKey.D2 && input.Key != ConsoleKey.D3);

                    if (input.Key == ConsoleKey.D1)
                    {
                        return scheduleDate.AddHours(12);
                    }
                    else if (input.Key == ConsoleKey.D2)
                    {
                        return scheduleDate.AddHours(15);
                    }
                    else if (input.Key == ConsoleKey.D3)
                    {
                        return scheduleDate.AddHours(20);
                    }
                }
                else
                {
                    Display($"{readFromUser} is not a valid date...\nPlease try again (⇀‸↼‶)");
                }
            }
        }

        internal override void Show()
        {
            Log("[Step 4]");

            ConsoleKeyInfo input;

            do
            {
                Console.Clear();
                GetDateInput();

                input = Console.ReadKey();


            } while (input.Key != ConsoleKey.D1 && input.Key != ConsoleKey.D2 && input.Key != ConsoleKey.D3 && input.Key != ConsoleKey.D4 && input.Key != ConsoleKey.D5 && input.Key != ConsoleKey.D6 && input.Key != ConsoleKey.D7 && input.Key != ConsoleKey.D8 && input.Key != ConsoleKey.D9);

            if (input.Key == ConsoleKey.D1)
            {

            }
        }
    }
}


