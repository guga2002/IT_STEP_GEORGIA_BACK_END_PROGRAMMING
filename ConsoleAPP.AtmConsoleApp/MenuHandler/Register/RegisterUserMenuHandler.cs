
namespace ConsoleAPP.AtmConsoleApp.MenuHandler.Register
{
    public class RegisterUserMenuHandler:MenuContext.MenuContext
    {
        public RegisterUserMenuHandler() : base()
        {
        }

        private (ConsoleKey, string)[] getmenucontext()
        {
            return new[]
             {
               (ConsoleKey.Q, "Let's Create new Bank Account !"),
               (ConsoleKey.W, "Check Balance "),
               (ConsoleKey.E, "Withdraw money from account"),
               (ConsoleKey.R, "deposite money to Bank Account !"),
               (ConsoleKey.T, "Sign Out"),
               (ConsoleKey.Y, "Exit From App"),

          };
        }

        public ConsoleKey start()
        {
        modiaq:
            Thread.Sleep(600);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Welcome , let's  choice operation");
            foreach (var item in getmenucontext())
            {
                Console.WriteLine($"<{item.Item1}> --> {item.Item2} \n");
            }
            Console.WriteLine("------------------------------------- ");
            Console.ResetColor();
            ConsoleKey choice = Console.ReadKey().Key;
            if (!RegisterMenu.ContainsKey(choice))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine("msgavsi operacia ar arsebobs gtxovt sworad airchiot");
                Console.ResetColor();
                goto modiaq;
            }
            return choice;
        }
    }
}
