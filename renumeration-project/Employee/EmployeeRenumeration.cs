using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.Employee
{
    internal class EmployeeRenumeration : Employee
    {
        public EmployeeRenumeration() { }

        public EmployeeRenumeration(string name, string surname, decimal Money, int bonus) : base(name, surname) 
        {
            if (bonus > 0)
            {
                using (var writer = File.AppendText($"{name} {surname}"))
                using (var auto = File.AppendText($"{AUTOSAVE}"))
                {
                    writer.WriteLine($"{Money}");
                    auto.WriteLine($"{name} {surname}, renumeration: {Money - bonus}, bonus: {bonus}, Time: " + DateTime.UtcNow);
                }
                WriteMessage($"Employee {name} {surname} added. Renumeration - {Money - bonus}, bonus - {bonus}, sum = {Money}. " +
                    $"Press any key to continue.", true,
                SettingWarnings.Success);
            }
            else
            {
                using (var writer = File.AppendText($"{name} {surname}"))
                using (var auto = File.AppendText($"{AUTOSAVE}"))
                {
                    writer.WriteLine($"{Money}");
                    auto.WriteLine($"{name} {surname}, renumeration: {Money}, bonus: not awarded, Time: " + DateTime.UtcNow);
                }
                WriteMessage($"Employee {name} {surname} added. Renumeration - {Money}, bonus - not awarded, sum = {Money}. " +
                    $"Press any key to continue.", true,
                SettingWarnings.Success);
            }
        }

        public EmployeeRenumeration(string name, string surname, byte age, decimal Money, int bonus) : base(name, surname, age) 
        {
            if (bonus > 0)
            {
                using (var writer = File.AppendText($"{name} {surname}"))
                using (var auto = File.AppendText($"{AUTOSAVE}"))
                {
                    writer.WriteLine($"{Money}");
                    auto.WriteLine($"{name} {surname}, age - {age}, renumeration: {Money - bonus}, bonus: {bonus}, Time: " + DateTime.UtcNow);
                }
                WriteMessage($"Employee {name} {surname}, age: {age} added. Renumeration - {Money - bonus}, bonus - {bonus}, sum = {Money}. " +
                    $"Press any key to continue.", true,
                SettingWarnings.Success);
            }
            else
            {
                using (var writer = File.AppendText($"{name} {surname}"))
                using (var auto = File.AppendText($"{AUTOSAVE}"))
                {
                    writer.WriteLine($"{Money}");
                    auto.WriteLine($"{name} {surname}, age - {age}, renumeration: {Money}, bonus: not awarded, Time: " + DateTime.UtcNow);
                }
                WriteMessage($"Employee {name} {surname}, age: {age} added. Renumeration - {Money}, bonus - not awarded, sum = {Money}. " +
                    $"Press any key to continue.", true,
                SettingWarnings.Success);
            }
        }

        public void renumerationForEmployee(string name, string surname, byte age)
        {
            while (EndRenumeration)
            {
                try
                {
                    Console.Write($"Renumeration for {name} {surname}: ");
                    decimal Money = decimal.Parse(Console.ReadLine());
                    if (MinimumWage > Money)
                    {
                        WriteMessage($"Renumeration is too low. Minimum - {MinimumWage}. Press any key to try again.", true,
                        SettingWarnings.Warning);
                        EndRenumeration = true;
                    }
                    else
                    {
                        while (CorrectBonus)
                        {
                            Console.Write($"Do you want give bonus for {name} {surname}? [yes/no]: ");
                            string bonusDecision = Console.ReadLine();
                            if (bonusDecision == "yes")
                            {
                                Console.Write($"Bonus for employee [100-500]: ");
                                int bonus = int.Parse(Console.ReadLine());
                                if (bonus < 100 || 500 < bonus)
                                {
                                    WriteMessage($"Incorrect value of bonus.  Press any key to try again.", true, SettingWarnings.Error);
                                    CorrectBonus = true;
                                }
                                else
                                {
                                    Money += bonus;
                                    RenumerationIfAge(name, surname, age, Money, bonus);
                                    CorrectBonus = false;
                                    EndRenumeration = false;
                                }
                            }
                            else if (bonusDecision == "no")
                            {
                                RenumerationIfAge(name, surname, age, Money, bonus);
                                CorrectBonus = false;
                                EndRenumeration= false;
                            }
                            else
                            {
                                WriteMessage($"Incorrect format. Press any key to try again.", true, SettingWarnings.Error);
                                CorrectBonus = true;
                            }
                        }
                    }
                }
                catch (FormatException format)
                {
                    WriteMessage($"{format.Message}. Renumeration for {name} {surname} not added. Press any key to try again.", true, SettingWarnings.Error);
                    EndRenumeration = true;
                }
                catch (OutOfMemoryException memoryException)
                {
                    WriteMessage($"{memoryException.Message}. Renumeration for {name} {surname} not added. Press any key to try again.", true, SettingWarnings.Error);
                    EndRenumeration = true;
                }
                catch (IOException ioException)
                {
                    WriteMessage($"{ioException.Message}. Renumeration for {name} {surname} not added. Press any key to try again.", true, SettingWarnings.Error);
                    EndRenumeration = true;
                }
                catch (Exception exception)
                {
                    WriteMessage($"{exception.Message}. Renumeration for {name} {surname} not added. Press any key to try again.", true, SettingWarnings.Error);
                    EndRenumeration = true;
                }
            }
        }

        private void RenumerationIfAge(string name, string surname, byte age, decimal Money, int bonus)
        {
            if (age > 0)
            {
                person = new EmployeeRenumeration(name, surname, age, Money, bonus);
            }
            else
            {
                person = new EmployeeRenumeration(name, surname, Money, bonus);
            }
        }
    }
}
