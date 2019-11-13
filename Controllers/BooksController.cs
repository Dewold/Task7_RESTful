using Task7_RESTful.Models;
using Task7_RESTful.Services;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.OData;
using System.Threading.Tasks;

namespace Task7_RESTful.Controllers
{
    public class BooksController : ODataController
    {
        private IBookRepository bookRepository;

        public BooksController()
        {
            this.bookRepository =
                new BookRepository(new BookCatalogContext());
        }

        public BooksController(IBookRepository repository)
        {
            this.bookRepository = repository;
        }

        // GET: /Books
        [EnableQuery]
        public IQueryable<Book> Get()
        {
            return bookRepository.GetAll();
        }

        // GET: /Books/{id}
        [EnableQuery]
        public SingleResult<Book> Get([FromODataUri] int key)
        {
            var result = bookRepository.Get(key);
            return SingleResult.Create(result);
        }

        // GET: /Books/{id}/Genre
        [EnableQuery]
        public SingleResult<Genre> GetGenre([FromODataUri] int key)
        {
            var result = bookRepository.GetGenre(key);
            return SingleResult.Create(result);
        }

        // POST: /Books
        public async Task<IHttpActionResult> Post(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await bookRepository.Create(book);
            return Created(book);
        }

        // PUT: /Books/{id}
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Book updateBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != updateBook.Id)
            {
                return BadRequest();
            }
            try
            {
                await bookRepository.Update(updateBook);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookRepository.BookExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(updateBook);
        }

        // DELETE: /Books/{id}
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            await bookRepository.Delete(key);
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            bookRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}