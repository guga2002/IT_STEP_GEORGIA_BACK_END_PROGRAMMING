using ConsoleAPP.AtmConsoleApp.Controllers;

namespace ConsoleAPP.AtmConsoleApp.MenuContext
{
    public class MenuContext
    {
        public Dictionary<ConsoleKey, Action> Guestmenu;// aq gveqneba metodebi momxareblis tipis mixedvit

        public Dictionary<ConsoleKey, Action> RegisterMenu;

        private readonly AtmController controll;

        public MenuContext()
        {
            Guestmenu = new Dictionary<ConsoleKey, Action>();
            RegisterMenu = new Dictionary<ConsoleKey, Action>();
            controll = new AtmController();
            Loadmenu();
        }

        private void Loadmenu()
        {
            Guestmenu.Add(ConsoleKey.A, controll.SignIn);
            Guestmenu.Add(ConsoleKey.E, controll.RegisterUser);
            Guestmenu.Add(ConsoleKey.X, controll.ExitFromApp);

            RegisterMenu.Add(ConsoleKey.Q, controll.CreateBankAccount);
            RegisterMenu.Add(ConsoleKey.W, controll.CheckBalance);
            RegisterMenu.Add(ConsoleKey.E, controll.withdraw);
            RegisterMenu.Add(ConsoleKey.R, controll.Deposite);
            RegisterMenu.Add(ConsoleKey.T, controll.SignedOut);
            RegisterMenu.Add(ConsoleKey.Y, controll.ExitFromApp);
        }
    }
}
