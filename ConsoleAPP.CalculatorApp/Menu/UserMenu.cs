using CalculatorApp.context;

namespace CalculatorApp.Menu
{
    public static class UserMenu
    {

        public static void doMain()
        {
            again:
            try
            {
                CalculatorContext context = new CalculatorContext();

                var Actions = context.GetContext();

                string choic = "no";
                do
                {
                modiaq:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine(" W     E    L    C    O     M     E  ! ");
                    Console.WriteLine("ATTENTION!! use Keys from right Side of keyboard, turn it using Nums lock !! ATTENTION");
                    Console.WriteLine("choice Operands");
                    Console.WriteLine("<+> Addition");
                    Console.WriteLine("<-> Substraction");
                    Console.WriteLine("<*> Multiplication");
                    Console.WriteLine("</> divide");
                    Console.WriteLine("------------------------------------------------");
                    ConsoleKey choice = Console.ReadKey().Key;
                    Console.ResetColor();

                    if (!Actions.ContainsKey(choice))
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("msgavsi operacia ar arsebobs !!");
                        Console.ResetColor();
                        Thread.Sleep(500);
                        goto modiaq;
                    }
                    else
                    {
                        Actions[choice].Invoke();
                    }
                    Console.WriteLine("want Use Calculator Again? Y/N");
                    choic = Console.ReadLine() ?? "N";

                } while (choic == "Y");

            }
            catch(DivideByZeroException exp)
            {
                Console.Clear();
                Console.WriteLine(exp.Message);
                Thread.Sleep(900);
                goto again;
            }
            catch (Exception exp)
            {
                Console.Clear();
                Console.WriteLine(exp.Message);
                Thread.Sleep(900);
                goto again;
            }
            finally
            {
                Console.WriteLine( "good Bye , see you later!");
            }
        }
    }
}
