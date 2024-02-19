using ConsoleAPP.AtmConsoleApp.Controllers;
using ConsoleAPP.AtmConsoleApp.Entities;
using ConsoleAPP.AtmConsoleApp.MenuHandler.Guest;
using ConsoleAPP.AtmConsoleApp.MenuHandler.Register;

namespace ConsoleAPP.AtmConsoleApp.main
{
    public  static class Mainclass
    {
        public static void  doinman()
        {
            AtmController cont = new AtmController();

            GuestMenuHandler handleguest = new GuestMenuHandler();
            RegisterUserMenuHandler register = new RegisterUserMenuHandler();
            try
            {
                User? activeUser = AtmController.activeUser;
                do
                {
                    do
                    {

                        ConsoleKey choic = handleguest.start();
                        handleguest.Guestmenu[choic].Invoke();
                        activeUser = AtmController.activeUser;
                    } while (activeUser == null);
                    Console.WriteLine("damtavrda fori");
                    do
                    {
                        ConsoleKey choic = register.start();
                        handleguest.RegisterMenu[choic].Invoke();
                        activeUser = AtmController.activeUser;

                    } while (activeUser != null);

                } while (true);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally
            {
                Console.WriteLine("Bye Bye !!");
            }

        }
    }
}
