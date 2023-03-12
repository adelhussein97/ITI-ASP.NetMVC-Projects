namespace WebApplication1.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public IEnumerable<Book> BookAuthor { get; set; }
    }
}
