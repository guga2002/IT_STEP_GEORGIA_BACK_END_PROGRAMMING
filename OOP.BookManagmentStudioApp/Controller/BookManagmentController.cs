using BookManagmentSystemApp.DbContext;
using BookManagmentSystemApp.Interfaces;

namespace BookManagmentSystemApp.Controller
{
    public class BookManagmentController
    {
        private readonly IbookManagment manage;

        public BookManagmentController()
        {
            BookManagmentDB Db = new BookManagmentDB();
            manage = new BookManagmentServices.BookManagmentSystem(Db);
        }

        public void Addbook()
        {
            var book = Helper.InputHelper.ReadBook("Let's Add new Book TO DB");
            manage.Addbook(book);
        }

        public void EditBook()
        {
            var book = Helper.InputHelper.ReadBook("Let's update data , enter the details", true);
            manage.EditBook(book);
        }

        public void GetAllBooks()
        {
            var res = manage.GetAllBooks();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            res.ForEach(io => { Console.WriteLine(io); });
            Console.ResetColor();
        }

        public void SearchUsingCaption()
        {
            var name = Helper.InputHelper.ReadDateforidentity("enter book caption To search");
            var book = manage.SearchUsingCaption(name);
            Console.WriteLine(book);
        }

        public void DeleteById()
        {
            var ID = Helper.InputHelper.ReadDateforidentity("Enter BOok ID for Delete!", true);
            manage.DeleteById(ID);
        }

        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string Choice = "";
            Console.WriteLine("Hope  You Liked, Our APP, if you wonder, please Give US feadback.");
            Console.WriteLine("Y/N?");
            Choice = Console.ReadLine()??"N";
            if(Choice=="Y")
            {
                string response = "";
                Console.WriteLine("Please Give us feadback, tell what would you like to change (develop) in APP");
                response = Console.ReadLine()??"User do not give  feadback!!!";// amas gamoviyenebt  bazashi chasawerad momxamreblis feadbackshi 
                Console.WriteLine("thanks,for your  opinion! See you soon <3");
                Console.ResetColor();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Goodbye, see you around!");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }
    }
}
