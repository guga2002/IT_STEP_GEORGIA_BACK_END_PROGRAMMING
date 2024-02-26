using RandomNumber.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumber.Controller
{
    public class RandomNumberController : AbstractRepos
    {
        public RandomNumberController(int maxAttempts) : base(maxAttempts) { }

        protected override void Play()
        {
            Console.WriteLine($"Guess the number between 1 and 100. You have {maxAttempts} attempts.");

            while (currentAttempt < maxAttempts)
            {
                Console.Write("Enter your guess: ");
                try
                {
                    int guess = int.Parse(Console.ReadLine());
                    currentAttempt++;

                    if (guess == targetNumber)
                    {
                        Console.WriteLine($"Congratulations! You guessed the correct number in {currentAttempt} attempts.");
                        return;
                    }
                    else if (guess < targetNumber)
                    {
                        Console.WriteLine($"Incorrect guess. The correct number is greater. Attempts remaining: {maxAttempts - currentAttempt}");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect guess. The correct number is smaller. Attempts remaining: {maxAttempts - currentAttempt}");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            Console.WriteLine("Sorry, you've run out of attempts. Better luck next time!");
        }
    }
}
