namespace BookManagmentSystemApp.Entities
{
    public class Author:AbstractEntity
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int Age { get; set; }
        public Author():base()
        {
                
        }

        public Author(string id,string name, string surname,int age):base(id)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;  
        }

        public override string ToString()
        {
            return $"{base.ToString()}AUTHOR->Name:{Name};Surname:{Surname};Age:{Age};";
        }
    }
}
