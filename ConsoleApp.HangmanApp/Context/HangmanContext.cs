

namespace ConsoleApp.HangmanApp.Context
{
    public class HangmanContext
    {
        public int countofwords { get; set; }
        public List<string> randomWords;
        public HangmanContext(int countofwords)
        {
            randomWords = new List<string>();
            this.countofwords = countofwords;
            loaddata();
        }

        private void loaddata()
        {
            var res = Faker.Lorem.Words(countofwords);
            randomWords.AddRange(res);
        }
    }
}
