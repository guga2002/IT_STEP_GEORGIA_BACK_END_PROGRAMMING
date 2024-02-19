
namespace ConsoleAPP.AtmConsoleApp.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public bool Isactive { get; set; } = false;
        public string PersonalNumber { get; set; }

        public int age { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public User(string name,string surname,string personalnumber,int age):base()
        {
            this.Name = name;
            this.Surname = surname;
            this.PersonalNumber = personalnumber;
            this.age = age;    
        }

        public User():base()
        {
                
        }

        public override string ToString()
        {
            return $"{base.ToString()} Name:{Name};Surname{Surname};Username:{Username};PersonalNumber:{PersonalNumber};Age:{age};";
        }
    }
}
