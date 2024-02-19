using BookManagmentSystemApp.Entities;

namespace BookManagmentSystemApp.Interfaces
{
    public interface IbookManagment
    {
        void Addbook(Book bk);

        void EditBook(Book bk);

        List<Book> GetAllBooks();

        Book SearchUsingCaption(string name);

        void DeleteBook(Book bk);

        void DeleteById(string id);
    }
}
