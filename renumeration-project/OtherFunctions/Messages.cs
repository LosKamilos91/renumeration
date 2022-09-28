using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.OtherFunctions
{
    public class Messages
    {
        public enum SettingWarnings { Warning, Success, Information, Error }

        public static void WriteMessage(params string[] message)
        {
            foreach (var textMessage in message)
            {
                Console.WriteLine($"{textMessage}");
            }
        }

        public static void WriteMessage(string description, bool consoleClear = false, SettingWarnings setting = SettingWarnings.Warning)
        {
            if (setting == SettingWarnings.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Success: {description}");
                Console.ResetColor();
            }
            else if (setting == SettingWarnings.Information)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Information: {description}");
                Console.ResetColor();
            }
            else if (setting == SettingWarnings.Warning)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Warning: {description}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {description}");
                Console.ResetColor();
            }
            if (consoleClear)
            {
                Console.ReadKey();
            }
        }
    }
}
