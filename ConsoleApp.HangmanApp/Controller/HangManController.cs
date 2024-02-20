using ConsoleApp.HangmanApp.Context;
using ConsoleApp.HangmanApp.HungManServices;
using ConsoleApp.HangmanApp.Interfaces;

namespace ConsoleApp.HangmanApp.Controller
{
    public class HangManController
    {
        private readonly IHangMan hangman;
      
        public int wordCount { get; set; } = 10;

        public HangManController()
        {
            hangman = new HungmanService(new HangmanContext(wordCount));
        }
        public void StartGame()
        {
            hangman.StartGame();
        }
    }
}
