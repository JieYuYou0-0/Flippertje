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
        internal SettingDate()
        {

        }

        internal DateTime GetDateInput()
        {
            var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
            while (true)
            {
                Console.WriteLine("Set your date: ");
                string readFromUser = Console.ReadLine();
                DateTime scheduleDate;
                if (DateTime.TryParseExact(readFromUser, dateFormats, DateTimeFormatInfo.InvariantInfo,
                        DateTimeStyles.None, out scheduleDate) && scheduleDate > DateTime.Now &&
                    scheduleDate.Date != DateTime.Now.Date)
                {
                    Console.WriteLine("At what time are you planning to visit us?");
                    ConsoleKeyInfo input;
                    do
                    {
                        Console.WriteLine("You can choose: \n" +
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
                    Console.WriteLine($"{readFromUser} is not a valid date...\nPlease try again (⇀‸↼‶)");
                }
            }
        }
    }
}


