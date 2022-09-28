namespace renumeration_project.Main
{
    public abstract partial class BasicFunctions : SelectOptions
    {
        public static void StartProgram()
        {
            bool start = true;
            while (start)
            {
                Console.Clear();
                WriteMessage(
                                "[1] - Add employee",
                                "[2] - Show employee",
                                "[3] - Employee statistics",
                                "[0] - Exit"
                            );
                try
                {
                    Console.Write("Select number: ");
                    byte SelectNumberMenu = byte.Parse(Console.ReadLine());
                    if (SelectNumberMenu == 0)
                    {
                        bool whetherExit = ExitProgram(start);
                        start = whetherExit;
                    }
                    else if (SelectNumberMenu <= 4 || 1 >= SelectNumberMenu)
                    {
                        SelectOptionsMenu(SelectNumberMenu);
                    }
                    else
                    {
                        WriteMessage("Wrong value. Press any key to try again.", true, SettingWarnings.Warning);
                        start = true;
                    }
                }
                catch (ArgumentNullException nullArgument)
                {
                    WriteMessage($"{nullArgument.Message}. Press any key to return to the menu.", true, SettingWarnings.Error);
                    start = true;
                }
                catch (FormatException format)
                {
                    WriteMessage($"{format.Message}. Press any key to return to the menu.", true, SettingWarnings.Error);
                    start = true;
                }
                catch (OverflowException overflow)
                {
                    WriteMessage($"{overflow.Message}. Press any key to return to the menu.",
                        true, SettingWarnings.Error);
                    start = true;
                }
                catch (Exception exc)
                {
                    WriteMessage($"{exc.Message}. Press any key to return to the menu. ", true, SettingWarnings.Error);
                    start = true;
                }
            }
        }
    }
}
