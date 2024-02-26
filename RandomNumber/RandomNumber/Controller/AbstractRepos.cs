using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber.Controller
{
    public abstract class AbstractRepos
    {
        protected int targetNumber;
        protected int maxAttempts;
        protected int currentAttempt;

        public AbstractRepos(int maxAttempts)
        {
            this.maxAttempts = maxAttempts;
        }

        public virtual void Start()
        {
            Initialize();
            Play();
            DisplayResult();
        }

        protected virtual void Initialize()
        {
            Random random = new Random();
            targetNumber = random.Next(1, 101);
            currentAttempt = 0;
        }

        protected abstract void Play();

        protected virtual void DisplayResult()
        {
            Console.WriteLine($"The correct number was {targetNumber}");
            Console.WriteLine($"Game over! You took {currentAttempt} attempts.");
        }
    }
}
