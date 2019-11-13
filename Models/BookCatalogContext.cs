using System.Data.Entity;

namespace Task7_RESTful.Models
{
    public class BookCatalogContext : DbContext
    {
        public BookCatalogContext()
                : base("name=BookCatalogContext")
        {
            Database.SetInitializer(new CatalogInitializer<BookCatalogContext>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}