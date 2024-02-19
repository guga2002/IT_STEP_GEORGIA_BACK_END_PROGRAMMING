namespace BookManagmentSystemApp.Entities
{
    public class Book:AbstractEntity
    {
        public string? Caption { get; set; }

        public DateTime RelaseDate { get; set; }

        public Author? author { get; set; }

        public Book():base()
        {
                
        }

        public Book(string id, string caption, DateTime relase,Author auth):base(id)
        {
            this.Caption = caption;
            this.RelaseDate = relase;
            this.author = auth;     
        }

        public override string ToString()
        {
            return $"{base.ToString()} BOOK->Caption:{Caption};RelaseDate:{RelaseDate};Author:{author} \n";
        }
    }
}
