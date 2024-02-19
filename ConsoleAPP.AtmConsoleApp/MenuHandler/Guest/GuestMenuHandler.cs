namespace ConsoleAPP.AtmConsoleApp.MenuHandler.Guest
{
    public class GuestMenuHandler:MenuContext.MenuContext
    {
        public GuestMenuHandler():base()
        {
        }

        private (ConsoleKey, string)[] getmenucontext()
        {
            return new[]
             {
               (ConsoleKey.A, "sign In to the system"),
               (ConsoleKey.E, "do not have account? let's register."),
               (ConsoleKey.X, "Exii app "),
          };
        }

        public ConsoleKey start()
        {
            modiaq:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(  "--------------------------------------");
            Console.WriteLine(  " W     E      L     C    O    M    E !");
            Console.WriteLine( "Hello Guest , let's  choice operation\n");
            foreach (var item in getmenucontext())
            {
                Console.WriteLine( $"<{item.Item1}> --> {item.Item2}");
            }
            Console.WriteLine(  "\n-----------------------------------");

            ConsoleKey choice = Console.ReadKey().Key;
            Console.ResetColor();
            if (!this.Guestmenu.ContainsKey(choice))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine( "ATTENTION! No Such  Operation Exist , please Choice another One ,!ATTENTION");
                Console.ResetColor();
                Thread.Sleep(800);
                goto modiaq;
            }
            return choice;
        }

    }
}
