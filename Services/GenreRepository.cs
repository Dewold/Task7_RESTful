using System;
using System.Linq;
using System.Threading.Tasks;
using Task7_RESTful.Models;

namespace Task7_RESTful.Services
{
    public class GenreRepository : IGenreRepository, IDisposable
    {
        private BookCatalogContext context;
        private bool disposed = false;

        public GenreRepository(BookCatalogContext ctx)
        {
            this.context = ctx;
        }

        public async Task Create(Genre item)
        {
            context.Genres.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var genre = await context.Genres.FindAsync(id);

            if (genre != null)
            {
                context.Genres.Remove(genre);
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

        public bool GenreExists(int id)
        {
            return context.Genres.Any(g => g.Id == id);
        }

        public IQueryable<Genre> Get(int id)
        {
            var genre = context.Genres
                .Where(g => g.Id == id);

            return genre;
        }

        public IQueryable<Book> GetBooks(int id)
        {
            var books = context.Genres
                .Where(g => g.Id.Equals(id))
                .SelectMany(b => b.Books);

            return books;
        }

        public IQueryable<Genre> GetAll()
        {
            return context.Genres.AsQueryable();
        }

        public async Task Update(Genre item)
        {
            context.Entry(item).State =
                System.Data.Entity.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}