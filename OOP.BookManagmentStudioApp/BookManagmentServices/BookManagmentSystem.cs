
using BookManagmentSystemApp.DbContext;
using BookManagmentSystemApp.Entities;
using BookManagmentSystemApp.Interfaces;

namespace BookManagmentSystemApp.BookManagmentServices
{
    public class BookManagmentSystem: AbstractService,IbookManagment
    {
        private readonly List<Book> booksentity;
        public BookManagmentSystem(BookManagmentDB db):base(db) {

            booksentity = context.GetContext();
        }

        public void Addbook(Book bk)
        {
            booksentity.Add(bk);
            Console.WriteLine("Book INsert TO DB succesfully!!");
        }

        public void DeleteBook(Book bk)
        {
            booksentity.Remove(bk);
        }

        public void DeleteById(string id)
        {
           var res= booksentity.FirstOrDefault(io => io.Identificator == id);
            if(res!=null)
            {
                booksentity.Remove(res);
            }
            Console.WriteLine("msgavsi  wigni ar moidzebna \n");
        }

        public void EditBook(Book bk)
        {
           var book= booksentity.Where(io => io.Caption.Equals(bk.Caption)).FirstOrDefault();
            if (book != null)
            {
                book.RelaseDate = bk.RelaseDate;
                book.author = bk.author;
                book.Caption = bk.Caption;
            }
            else
            {
                Console.WriteLine("msgavsi wigni ar arsebobs :((((");
            }
        }

        public List<Book> GetAllBooks()
        {
            return booksentity.ToList();
        }

        public Book SearchUsingCaption(string name)
        {
            var res = from book in booksentity
                      where book.Caption.Equals(name)
                      select book;
            if (res != null)
            {
                return res.First();
            }
            return new Book();
        }
    }
}
