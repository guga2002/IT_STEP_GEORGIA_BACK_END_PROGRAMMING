using ConsoleAPP.AtmConsoleApp.DbContexts;

namespace ConsoleAPP.AtmConsoleApp.AtmServices
{
    public abstract class abstractRepository
    {
        protected readonly AtmContext context;

        protected abstractRepository(AtmContext con)
        {
            context = con;
        }
    }
}
