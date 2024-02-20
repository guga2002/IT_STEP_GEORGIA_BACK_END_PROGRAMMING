using ConsoleApp.HangmanApp.Context;

namespace ConsoleApp.HangmanApp.HungManServices
{
    public abstract class AbstractRepos
    {
        protected readonly HangmanContext context;

        protected AbstractRepos(HangmanContext con)
        {
            context = con;    
        }
    }
}
