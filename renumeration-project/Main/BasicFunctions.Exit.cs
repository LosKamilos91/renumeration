using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renumeration_project.Main
{
    public abstract partial class BasicFunctions
    {
        public static bool ExitProgram(bool exitProgram)
        {
            Console.Write("Do you want exit program? [yes/no]: ");
            string exit = Console.ReadLine().ToLower();
            if (exit == "yes")
            {
                return exitProgram = false;
            }
            else if (exit == "no")
            {
                return exitProgram = true;
            }
            else
            {
                throw new Exception($"You entered the wrong value. The correct value is 'yes' or 'no'. Your entered value is '{exit}'. " +
                    $"Press any key to return to the menu");
            }
        }
    }
}
