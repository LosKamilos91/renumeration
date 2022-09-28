using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.OtherFunctions
{
    public class InMemoryEmployee : Employee.Employee
    {
        public InMemoryEmployee(string name, string surname) : base(name, surname) 
        {
            Name = name;
            Surname = surname;
        }

        public InMemoryEmployee(string name, string surname, int age) : base(name, surname, age) { }

        public void AddRemuneration(decimal money)
        {
            if (money < MinimumWage)
            {
                Console.WriteLine($"Can't add remuneration for [{Name} { Surname}] because value < " + MinimumWage);
            }
            else
            {
                Console.WriteLine($"Added: [{Name} {Surname}].");
            }
        }
    }
}
