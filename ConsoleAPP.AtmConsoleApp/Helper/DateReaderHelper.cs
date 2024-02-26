using ConsoleAPP.AtmConsoleApp.Entities;
using ConsoleAPP.AtmConsoleApp.Validation;


namespace ConsoleAPP.AtmConsoleApp.Helper
{
    public static class DateReaderHelper
    {
        public static  (string,string)  SigninRead()
        {
            Mod:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine( "let's sign in");
            Console.WriteLine("enter Login");
            string login = Console.ReadLine();
            Console.WriteLine("enter Password");
            string Password= Console.ReadLine();
          if(!CalidateVariables.ValidateUserName(login))
            {
                Console.WriteLine( "User ara validuri sheiyvane tavidan");
                goto Mod;
            }
            Console.ResetColor();
            if (login == null || Password == null) return ("guga", "guga");
            return (login, Password);
        }

        public static decimal AmountRead(string Caprtion)
        {
        Mod:
            decimal res = 0;
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Caprtion);
                Console.WriteLine("please enter amount");
                res = decimal.Parse(Console.ReadLine() ?? "0");
                Console.ResetColor();
            }
            catch (InvalidCastException xst)
            {
                Console.WriteLine(xst.Message);
                goto Mod;
            }
            return res;
        }
        public static User ReadUser()
        {
            Modul:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine( "let's add new User");
            Console.WriteLine( "enter Name");
            string Name = Console.ReadLine();
            Console.WriteLine( "enter Surname");
            string surnam = Console.ReadLine();
            Console.WriteLine( "enter personal Number");
            string pers = Console.ReadLine();
            Console.WriteLine( "enter age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("enter login");
            string login = Console.ReadLine();
            Console.WriteLine("enter password");
            string password = Console.ReadLine();
            Console.ResetColor();
            if(!CalidateVariables.NameValidate(Name)||!CalidateVariables.SurnameValidate(surnam)||!CalidateVariables.AgeISvalidate(age))
            {
                Console.WriteLine( "some argumnt is not correct , enter again");
                goto Modul;
            }
            User usr = new User(Name, surnam, pers, age)
            {
                Password = password,
                Username = login
            };

            return usr;
        }

        public static BankAccount ReadBankaccount(User us)
        {
            Random rand = new Random();
            BankAccount acnt = new BankAccount(us.Id, rand.Next(100, 1000), "Bank OF Georgia", "Iuridiuli");
            return acnt;
        }
    }
}
