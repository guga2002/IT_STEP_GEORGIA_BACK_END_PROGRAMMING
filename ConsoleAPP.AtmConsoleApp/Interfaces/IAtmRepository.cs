using ConsoleAPP.AtmConsoleApp.Entities;

namespace ConsoleAPP.AtmConsoleApp.Interfaces
{
    public interface IAtmRepository
    {
        User? SignIn(string user,string pass);

        bool SignedOut(User usr);

        User? RegisterUser(User usr);

        User? CheckBalance(User usr);

        User? withdraw(User usr, decimal Amount);

        User? Deposite(User usr,decimal Amount);

        BankAccount? CreateBankAccount(BankAccount acnt);
    }
}
