namespace renumeration_project.Main
{
    public abstract class SelectOptions : OtherFunctions.Messages
    {
        protected static void SelectOptionsMenu(byte select)
        {
            Employee.Employee employee = new Employee.Employee();
            switch (select)
            {
                case 1:
                    employee.NewEmployee();
                    break;
                case 2:
                    OtherFunctions.ShowEmployee showInConsole = new OtherFunctions.ShowEmployee();
                    break;
                case 3:
                    OtherFunctions.Statistics.StatsInConsole();
                    break;
            }
        }
    }
}
