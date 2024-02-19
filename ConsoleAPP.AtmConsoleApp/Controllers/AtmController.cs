using ConsoleAPP.AtmConsoleApp.AtmServices;
using ConsoleAPP.AtmConsoleApp.DbContexts;
using ConsoleAPP.AtmConsoleApp.Entities;
using ConsoleAPP.AtmConsoleApp.Interfaces;

namespace ConsoleAPP.AtmConsoleApp.Controllers
{
    public class AtmController
    {
        private readonly AtmContext db;
        private readonly IAtmRepository repos;
        public static User? activeUser;// am cvladit ganisazgvreba  momxareblis avtoorizebuloba
        public AtmController()
        {
            db=new AtmContext();
            repos = new AtmRepository(db);
            activeUser = null;
        }
        public void SignIn()
        {
            var res = Helper.DateReaderHelper.SigninRead();
            var use=repos.SignIn(res.Item1,res.Item2);
            if(use!=null)
            {
                Console.Clear();
                Console.WriteLine("momxarebeli warmatebit shevida sistemashi");
                Thread.Sleep(200);
                activeUser = use;
            }
        }

        public void  SignedOut()
        {
            if (activeUser != null)
            {
                repos.SignedOut(activeUser);
                activeUser = null;
                Console.Clear();
                Console.WriteLine("Warmatebit gamovedit sistemidan");
                Thread.Sleep(300);
            }
        }

       public void RegisterUser()
        {
            var res = Helper.DateReaderHelper.ReadUser();
            repos.RegisterUser(res);
            Console.Clear();
            Console.WriteLine( "user register sucesfully");
            Thread.Sleep(300);
        }

        public void CheckBalance()
        {
            if (activeUser != null)
            {
                repos.CheckBalance(activeUser);

            }
            else
            {
                Console.WriteLine( "Please Authorize at first , if you do not have account , create one");
            }
        }

        public void withdraw()
        {
            var res = Helper.DateReaderHelper.AmountRead("Let's withdraw money , enter amount");
            if (activeUser != null)
            {
                repos.withdraw(activeUser, res);
                Console.Clear();
                Console.WriteLine($"warmatebit gamoitanet tanxa {res} $");
                Thread.Sleep(300);
            }
            else
            {
                Console.WriteLine("first you must signed in!!");
            }
        }

        public void Deposite()
        {
            var res = Helper.DateReaderHelper.AmountRead("Let's Deposite money , enter amount");
            if (activeUser != null)
            {
                repos.Deposite(activeUser, res);
                Console.Clear();
                Console.WriteLine($"Warmatebit chairicxa{res}$ tqvens angarishze"); ;
                Thread.Sleep(300);
            }
            else
            {
                Console.WriteLine("first you must signed in!!");
            }
        }

        public void CreateBankAccount()
        {
            if (activeUser == null) Console.WriteLine("please sign in at first to reate bank account");
            else
            {
                var res = Helper.DateReaderHelper.ReadBankaccount(activeUser);
                var rep= repos.CreateBankAccount(res);
                Console.Clear();
                Console.WriteLine(  $"bankis angarishi warmatebit Sheiqmna , ID {rep.Id}");
                Thread.Sleep(300);
            }
        }

        public void ExitFromApp()
        {
            Console.Clear();
            Console.WriteLine( "GoodBye");
            Environment.Exit(0);
        }
    }
}
