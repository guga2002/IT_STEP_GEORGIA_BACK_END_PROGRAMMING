using BookManagmentSystemApp.Controller;

namespace BookManagmentSystemApp.Menu
{
    public static class MenuContext
    {
        public static BookManagmentController controll = new BookManagmentController();
        public static Dictionary<ConsoleKey,Action> operations=new Dictionary<ConsoleKey, Action>();
        public static (ConsoleKey id, string caption, Action action)[] Getmenu()
        {
            (ConsoleKey id, string caption, Action action)[] array = {
            (ConsoleKey.F1,"Add Book to Db",controll.Addbook),
               (ConsoleKey.F2,"Edit Specify Book",controll.EditBook),
                  (ConsoleKey.F3,"Get All Books Info",controll.GetAllBooks),
                   (ConsoleKey.F4,"Search Book Using Caption",controll.SearchUsingCaption),
                  (ConsoleKey.F5,"Delete Book By ID",controll.DeleteById),
                  (ConsoleKey.F6,"Logout from the app",controll.Exit),
            };
            return array;
        }
        public static void show()
        {
            var menu = Getmenu();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine( "---------------------------------");
            Console.WriteLine( "W  E  L  C  O   M   E  !\n");
            Console.WriteLine( "that is operations we offer:\n");
            foreach (var item in menu)
            {
                if (!operations.ContainsKey(item.id))
                {
                    operations.Add(item.id, item.action);
                }
                Console.WriteLine($"<{item.id}> --> {item.caption}");
            }
            Console.WriteLine( "<Space> --> refresh the menu!");
            Console.WriteLine("\n Press Any key , <ESC> For Leave!");
            Console.ResetColor();
        }

        public static ConsoleKey Getchoice()
        {
            ConsoleKey choice = ConsoleKey.None;
            show();
            do
            {
                choice = Console.ReadKey().Key;
                Console.Clear();
                if(choice==ConsoleKey.Escape)
                {
                    Console.WriteLine("G Bye, See you again!");
                    return ConsoleKey.None;
                }
                if (choice == ConsoleKey.Spacebar)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("refreshing ");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("refreshing ||");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("refreshing ||||||||||");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("refreshing |||||||||||||||||||||||");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("refreshing |||||||||||||||||||||||||||||||||||||");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.WriteLine("refreshing ||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
                    Thread.Sleep(400);
                    Console.Clear();
                    Console.ResetColor();
                    show();
                }
                else if(!operations.Keys.Contains(choice))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" ATTENTION!!! the operation, you have chosen is  not exist!");
                    Console.WriteLine("Press <ESC> for log out");
                    Console.ResetColor();
                    Thread.Sleep(700);
                    Console.Clear();
                    show();
                }
            } while (!operations.Keys.Contains(choice));
            return choice;
        }

        public static void Destroyer()
        {
            operations.Clear();
        }
    }
}
