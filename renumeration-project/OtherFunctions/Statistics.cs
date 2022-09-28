using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.OtherFunctions
{
    public class Statistics : Employee.Employee
    {
        public decimal Sum;
        public decimal Hight;
        public decimal Low;
        public int Count;

        public Statistics()
        {
            Count = 0;
            Sum = 0.0m;
            Hight = decimal.MinValue;
            Low = decimal.MaxValue;
        }

        public decimal Average
        {
            get
            {
                return statsEmp.Average(x => x);
            }
        }

        public void Add(decimal number)
        {
            Sum += number;
            Count += 1;
            Hight = Math.Max(number, Hight);
            Low = Math.Min(number, Low);
        }

        public static void StatsInConsole()
        {
            try
            {
                Console.WriteLine("Enter the name of the employee to whom you want to add the remuneration");
                Console.Write("Give name: ");
                string name = Console.ReadLine().ToLower();
                Console.Write("Give surname: ");
                string surname = Console.ReadLine().ToLower();
                using (var reader = File.OpenText($"{name} {surname}"))
                {
                    while (!reader.EndOfStream)
                    {
                        string readLine = reader.ReadLine();
                        decimal renum = decimal.Parse(readLine);
                        statsEmp.Add(renum);
                    }
                }
                Console.WriteLine();
                Console.WriteLine($"Statistic - {name} {surname}");
                Statistics stats = new Statistics();
                stats.GetStatistics();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                WriteMessage($"{ex.Message}", true, SettingWarnings.Error);
            }
        }
    }
}
