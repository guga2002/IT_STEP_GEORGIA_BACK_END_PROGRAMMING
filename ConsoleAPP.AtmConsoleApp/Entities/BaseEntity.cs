namespace ConsoleAPP.AtmConsoleApp.Entities
{
    public abstract  class BaseEntity
    {
        public string  Id { get; set; }

        public BaseEntity()
        {
            Id = inicialize();
        }
        private string inicialize()
        {
            string res = "";
            Random rand = new Random();
            string ran= "455435675474587544yfdhdfh";
            for (int i = 0; i < 13; i++)
            {
                res += ran[rand.Next(0, ran.Length - 1)];
            }
            return res;
        }

        public override string ToString()
        {
            return $" ID {Id};";
        }
    }
}
