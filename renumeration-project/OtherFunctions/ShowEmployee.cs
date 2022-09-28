using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.OtherFunctions
{
    internal class ShowEmployee : Employee.Employee
    {
        private int countEmployee = 0;
        public ShowEmployee()
        {
            try
            {
                Console.Clear();
                using (var reader = File.OpenText($"{SAVE}"))
                {
                    string readLine = reader.ReadLine();
                    Console.WriteLine(readLine);
                    while (readLine != null)
                    {
                        readLine = reader.ReadLine();
                        Console.WriteLine(readLine);
                        countEmployee++;
                    }
                }
                Console.WriteLine($"Employee/s: [{countEmployee}]");
                Console.WriteLine();
                WriteMessage("Press any key to return.", true,
                        SettingWarnings.Information);
            }
            catch (FileNotFoundException)
            {
                WriteMessage("File not exist. You need add employee. Press any key to try again.", true, SettingWarnings.Warning);
            }
            catch (ArgumentException)
            {
                WriteMessage("Bad argument!. Press any key to try again.", true, SettingWarnings.Warning);
            }
            catch (Exception)
            {
                WriteMessage("Something went wrong!. Press any key to try again.", true, SettingWarnings.Information);
            }
        }
    }
}
