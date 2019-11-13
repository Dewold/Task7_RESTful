using Microsoft.AspNet.OData;
using System.Linq;
using Task7_RESTful.Models;
using Task7_RESTful.Services;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace Task7_RESTful.Controllers
{
    public class GenresController : ODataController
    {
        private IGenreRepository genreRepository;

        public GenresController()
        {
            this.genreRepository =
                new GenreRepository(new BookCatalogContext());
        }

        public GenresController(IGenreRepository repository)
        {
            this.genreRepository = repository;
        }

        // GET: /Genres
        [EnableQuery]
        public IQueryable<Genre> Get()
        {
            return genreRepository.GetAll();
        }

        // GET: /Genres/{id}
        [EnableQuery]
        public SingleResult<Genre> Get([FromODataUri] int key)
        {
            var result = genreRepository.Get(key);
            return SingleResult.Create(result);
        }

        // GET: /Genres/{id}/Books
        [EnableQuery]
        public IQueryable<Book> GetBooks([FromODataUri] int key)
        {
            return genreRepository.GetBooks(key);
        }

        // POST: /Genres
        public async Task<IHttpActionResult> Post(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await genreRepository.Create(genre);
            return Created(genre);
        }

        // PUT: /Genres/{id}
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Genre updateGenre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != updateGenre.Id)
            {
                return BadRequest();
            }
            try
            {
                await genreRepository.Update(updateGenre);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!genreRepository.GenreExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(updateGenre);
        }

        // DELETE: /Genres/{id}
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            await genreRepository.Delete(key);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            genreRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}