using System;
using System.Linq;
using System.Threading.Tasks;
using Task7_RESTful.Models;

namespace Task7_RESTful.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private BookCatalogContext context;
        private bool disposed = false;

        public BookRepository(BookCatalogContext ctx)
        {
            this.context = ctx;
        }

        public bool BookExists(int id)
        {
            return context.Books.Any(p => p.Id == id);
        }

        public async Task Create(Book item)
        {
            context.Books.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await context.Books.FindAsync(id);

            if (book != null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IQueryable<Book> Get(int id)
        {
            var book = context.Books
                .Where(b => b.Id == id);

            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return context.Books.AsQueryable();
        }

        public IQueryable<Genre> GetGenre(int id)
        {
            var genre = context.Books.Where(b => b.Id == id)
                .Select(g => g.Genre);
            return genre;
        }

        public async Task Update(Book item)
        {
            context.Entry(item).State =
                System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}