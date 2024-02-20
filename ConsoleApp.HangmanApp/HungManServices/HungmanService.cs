using ConsoleApp.HangmanApp.Context;
using ConsoleApp.HangmanApp.Interfaces;
using System.Text;

namespace ConsoleApp.HangmanApp.HungManServices
{
    public class HungmanService:AbstractRepos, IHangMan
    {
        public string wordwithpattern { get; set; }

        public HungmanService(HangmanContext con):base(con)
        {
            wordwithpattern = "";
                
        }
        #region Start Game
        public void StartGame()
        {
            string choice = "";
            do
            {
                string word = CHoiceWord();
                Console.WriteLine( $"the answer is {word} showing for testing purpose");
                Console.WriteLine( "game will start soon...");
                Thread.Sleep(2000);
                int attempt = 2;
                Generatepattern(word);
                do
                {
                    var cha = AskForCHar();
                    if (isContain(word, cha))
                    {
                        wordwithpattern = Update(word, cha);
                    }
                    else
                    {
                        attempt--;
                        Console.WriteLine($"The char is not exist in word ,try again , you have Attempts {attempt}");
                        Thread.Sleep(600);
                    }

                } while (wordwithpattern.Contains('-') && attempt >= 0);

                if (attempt <=0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("game over , you lose :(");
                    Console.WriteLine("You Can play again :)");
                    Console.ResetColor();
                    Thread.Sleep(1200);
                    goto Conso;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta ;
                    Console.WriteLine($"shen warmatebit gamoicani sityva < {wordwithpattern} >");
                    Console.ResetColor();
                    Thread.Sleep(1200);
                }
            Conso:
                Console.WriteLine("wana  play again? Y/N");
                choice = Console.ReadLine()??"N";
            } while (choice=="Y");
        }
        #endregion

        #region Private Helper Functions
        private string Update(string word, char cht)
        {
            StringBuilder updatedWord = new StringBuilder(wordwithpattern);
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == cht)
                {
                    updatedWord[i] = cht;
                }
            }
            return updatedWord.ToString();
        }

        private char AskForCHar()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(  " Welcomne, let's play!");
            Console.WriteLine(  " H   U   N   G   M   A   N !\n");
            Console.WriteLine( wordwithpattern);
            Console.WriteLine("\nEnter the char");
            char archevan = char.Parse(Console.ReadLine());
            Console.ResetColor();
            return archevan;
        }

        private void Generatepattern(string word)
        {
            wordwithpattern = "";
            foreach (var item in word)
            {
                wordwithpattern += "-";
            }
        }

        private string CHoiceWord()
        {
            Random rnd = new Random();
            int count = context.randomWords.Count();
            string randword=context.randomWords[rnd.Next(0,count--)];
            Console.WriteLine(randword);
            return randword;
        }

        private bool isContain(string word,char gues)
        {

            foreach (var item in word)
            {
                if(item.Equals(gues))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
