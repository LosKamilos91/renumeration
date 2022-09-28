using renumeration_project.OtherFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.Employee
{
    public class Employee : Main.BasicFunctions, Interface.IEmployee
    {
        public Employee() { }
        public Employee(string name, string surname)
        {
            using (var nameEmployee = File.AppendText($"{SAVE}"))
            {
                nameEmployee.WriteLine($"{name.ToLower()} {surname.ToLower()}");
            }
        }

        public Employee(string name, string surname, int age)
        {
            using (var nameEmployee = File.AppendText($"{SAVE}"))
            {
                nameEmployee.WriteLine($"{name.ToLower()} {surname.ToLower()}, age: {age}");
            }
        }

        public static List<decimal> statsEmp = new List<decimal>();
        protected bool EndRenumeration = true;
        protected bool CorrectBonus = true;
        private bool enterAgainEmployee = true;
        
        protected decimal MinimumWage = 1800.00M;
        protected const string SAVE = "Employees.txt";
        protected const string AUTOSAVE = "audit.txt";
        protected int bonus;
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; private set; }
        protected Employee person;

        public void NewEmployee()
        {
            while (enterAgainEmployee)
            {
                Console.Write("Do you want add new Employee? [yes/no]: ");
                string newEmployee = Console.ReadLine().ToLower();
                if (newEmployee == "yes")
                {
                    Console.Write("Name employee: ");
                    Name = Console.ReadLine().ToLower();
                    Console.Write("Surname employee: ");
                    Surname = Console.ReadLine().ToLower();
                    AgeForEmployee age = new AgeForEmployee();
                    Age = age.AgeEmployee(Name, Surname);
                    EmployeeRenumeration renumerationEmployee = new EmployeeRenumeration();
                    renumerationEmployee.renumerationForEmployee(Name, Surname, Age);
                    enterAgainEmployee = true;
                }
                else
                {
                    if (newEmployee != "no")
                    {
                        WriteMessage($"You entered the wrong value. The correct value is 'yes' or 'no'. Your entered value is '{newEmployee}'. " +
                       $"Employee not added. Press any key to return to the menu", true, SettingWarnings.Error);
                    }
                    enterAgainEmployee = false;
                }
            }
        }

        public Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            result.Hight = Statistics.statsEmp.Max(x => x);
            result.Low = Statistics.statsEmp.Min(x => x);
            var sum = Statistics.statsEmp.Sum(x => x);
            Console.WriteLine("Average remuneration: {0:F2}", result.Average);
            Console.WriteLine("Hight remuneration: {0:F2}", result.Hight);
            Console.WriteLine("Low remuneration: {0:F2}", result.Low);
            Console.WriteLine("Sum remuneration: {0:F2}", sum);
            return result;
        }
    }
}
