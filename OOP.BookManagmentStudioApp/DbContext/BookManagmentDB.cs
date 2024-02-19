using BookManagmentSystemApp.Entities;

namespace BookManagmentSystemApp.DbContext
{
    public class BookManagmentDB
    {
        private List<Book> books;
        public BookManagmentDB()
        {
            books = new List<Book>();
            GenerateRandomData();
        }
        private void GenerateRandomData()
        {
            Random age = new Random();
            string Name = Faker.Name.First();
            string Surname = Faker.Name.Last();
            int ageofauthor = age.Next(10, 120);
            string caption = Faker.Company.Name();
            DateTime date = DateTime.Now.AddYears(-age.Next(10, 200));
            for (int i = 0; i < 20; i++)
            {
                Author auth = new Author()
                {
                    Age = ageofauthor,
                    Name = Name,
                    Surname = Surname,
                };
                Book book = new Book()
                {
                    RelaseDate = date,
                    author = auth,
                    Caption = caption,
                };
                books.Add(book);
            }
        }
        public List<Book> GetContext()
        {
            return books;
        }
    }
}
