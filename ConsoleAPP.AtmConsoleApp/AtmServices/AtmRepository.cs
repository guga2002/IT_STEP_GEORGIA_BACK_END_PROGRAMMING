using ConsoleAPP.AtmConsoleApp.DbContexts;
using ConsoleAPP.AtmConsoleApp.Entities;
using ConsoleAPP.AtmConsoleApp.Interfaces;

namespace ConsoleAPP.AtmConsoleApp.AtmServices
{
    public class AtmRepository:abstractRepository, IAtmRepository
    {
        private readonly List<User>? userset;
        private readonly List<BankAccount>? accountset;
        public AtmRepository(AtmContext con):base(con)
        {
            userset = context.GetSet<User>();
            accountset = context.GetSet<BankAccount>();
        }

       public User? CheckBalance(User check)
        {
            if (accountset == null) return null;
            var acnt = accountset.Where(io => io.UserId == check.Id).FirstOrDefault();
           if(acnt!=null)
            {
                Console.Clear();
                Console.WriteLine( $"your balance is {acnt.Balance}");
                Thread.Sleep(500);
                return check;
            }
            Console.WriteLine( "somethings unusual!");
            return null;// account ar aqvs
        }

       public BankAccount? CreateBankAccount(BankAccount acnt)
        {
            if (accountset == null) return null;
            accountset.Add(acnt);
            context.SaveChangesToFile();
            return accountset.LastOrDefault();

        }

        public User?  Deposite(User usr,decimal amount)
        {
            if (accountset == null) return null;
            var res = accountset.Where(io => io.UserId == usr.Id).FirstOrDefault();
            if(res!=null)
            {
                res.Balance += amount;
                context.SaveChangesToFile();
                return usr;
            }
            return null;
        }

        public User? RegisterUser(User usr)
        {
            if (userset == null) return null;
            userset.Add(usr);
            context.SaveChangesToFile();
            return userset.LastOrDefault();
        }

        public BankAccount? RegisterBankAccount(BankAccount acnt)
        {
            if (accountset == null) return null;
            accountset.Add(acnt);
            context.SaveChangesToFile();
            return accountset.LastOrDefault();
        }

        public bool SignedOut(User usr)
        {
            if (userset == null) return false;
           var user= userset.Where(io => io.PersonalNumber == usr.PersonalNumber).FirstOrDefault();
            if (user != null)
            {
                user.Isactive = false;
                context.SaveChangesToFile();
                return true;
            }
            else
            {
                return false;
            }
        }

        public User? SignIn(string User,string password)
        {
            if(userset!=null&&userset.Any(io=>io.Username==User &&io.Password==password))
            {
                var res = userset.Where(io => io.Username == User && io.Password == password).FirstOrDefault();
                return res;
            }
            return null;
        }

        public User? withdraw(User usr, decimal Amount)
        {
            if(userset==null ||accountset==null)
            {
                return null;
            }
            var res = userset.Where(io => io.PersonalNumber == usr.PersonalNumber).SingleOrDefault();
            if(res!=null)
            {
                var account = accountset.Where(io => io.UserId == res.Id).FirstOrDefault();
                if(account!=null)
                {
                    if(account.Balance>=Amount)
                    {
                        account.Balance -= Amount;
                        context.SaveChangesToFile();
                        Console.WriteLine( "Warmatebit gaitana tanxa");
                        return res;
                    }
                }
            }
            return null;
        }
    }
}
