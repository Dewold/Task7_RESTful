using System;
using System.Linq;
using System.Threading.Tasks;
using Task7_RESTful.Models;

namespace Task7_RESTful.Services
{
    public interface IBookRepository : IDisposable
    {
        IQueryable<Book> GetAll();
        IQueryable<Book> Get(int id);
        IQueryable<Genre> GetGenre(int id);
        Task Create(Book item);
        Task Update(Book item);
        Task Delete(int id);
        bool BookExists(int id);
    }

    public interface IGenreRepository : IDisposable
    {
        IQueryable<Genre> GetAll();
        IQueryable<Genre> Get(int id);
        IQueryable<Book> GetBooks(int id);
        Task Create(Genre item);
        Task Update(Genre item);
        Task Delete(int id);
        bool GenreExists(int id);
    }
}