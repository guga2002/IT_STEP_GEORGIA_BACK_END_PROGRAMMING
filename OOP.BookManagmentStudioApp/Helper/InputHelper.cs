using BookManagmentSystemApp.Entities;
using BookManagmentSystemApp.Validations;

namespace BookManagmentSystemApp.Helper
{
    public static  class InputHelper
    {
        public static Book ReadBook(string header, bool ident = false)
        {
            if(ident)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" ATTENTION! we identify Books Using Caption. ATTENTION!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Labe:
            Console.WriteLine( header);
            Author auth = new Author();
            Console.WriteLine("enter Author Name");
            string? Name = Console.ReadLine();
            Console.WriteLine("enter Author Surname");
            string? Surname = Console.ReadLine();
            Console.WriteLine("enter Age");
            int Age = int.Parse(Console.ReadLine()??"-1");
            if(!Validations.ValidateData.NameValidate(Name)||!ValidateData.SurnameValidate(Surname)||!ValidateData.AgeISvalidate(Age))
            {
                Console.WriteLine("Shetanili monacemebi arasworia , gtxovt tavidan sheitanot monacemebi");
                goto Labe;
            }
            auth.Name = Name;
            auth.Surname = Surname;
            auth.Age = Age;
            Console.WriteLine("Enter Caption");
            string caption = Console.ReadLine()??"saxeli";
            Book bks = new Book()
            { 
            author = auth,
            RelaseDate=DateTime.Now,
            Caption=caption,
            };
            Console.ResetColor();
            return bks;
        }

        public static string ReadDateforidentity(string capt,bool optional=false)
        {
            
            if (optional)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Attention!!!  you are  going to delete  book From Db :)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            aqmodi:
            Console.WriteLine(capt);
            string caption = Console.ReadLine()??"no exist!";
            if (!ValidateData.CaptionIsValid(capt))
            {
                Console.WriteLine("caption is not valid ");
                goto aqmodi;
            }
            Console.ResetColor();
            return caption;
        }

    }
}
