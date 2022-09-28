using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.Employee
{
    internal class AgeForEmployee : Employee
    {
        private bool correctAgeValue = true;
        byte age;
        public byte AgeEmployee(string name, string surname)
        {
            byte ageValue = 0;
            while (correctAgeValue)
            {
                Console.Write($"Do you want add age for {name} {surname}? [yes/no]: ");
                string ageDecision = Console.ReadLine().ToLower();
                if (ageDecision == "yes")
                {
                    Console.Write("Age: ");
                    age = byte.Parse(Console.ReadLine());
                    while (age >= 0)
                    {
                        if (age > 110 || 18 > age)
                        {
                            WriteMessage($"Wrong value '{nameof(age)}'. Press any key to try again.", true, SettingWarnings.Warning);
                            break;
                        }
                        else
                        {
                            WriteMessage($"Age added - {name} {surname} - {age}. Press any key to continue.", true, SettingWarnings.Success);
                            return ageValue += age;
                            correctAgeValue = false;
                        }
                    }
                }
                else
                {
                    if (ageDecision != "no")
                    {
                        WriteMessage($"Entered wrong value. The correct value is 'yes' or 'no'. Your entered value is '{ageDecision}'. " +
                          $"Age for {name} {surname} not added. Press any key too try again.", true, SettingWarnings.Error);
                        correctAgeValue = true;
                    }
                    else
                    {
                        WriteMessage($"Age not added. Press any key to continue.", true, SettingWarnings.Success);
                        correctAgeValue = false;
                    }
                }
            }
            return ageValue;
        }
    }
}
