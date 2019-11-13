using System.Collections.Generic;
using System.Data.Entity;

namespace Task7_RESTful.Models
{
    public class CatalogInitializer<T> : DropCreateDatabaseIfModelChanges<BookCatalogContext>
    {
        protected override void Seed(BookCatalogContext context)
        {
            IList<Book> defaultBooks = new List<Book>();
            IList<Genre> defaultGenres = new List<Genre>();

            #region SeedData
            defaultGenres.Add(new Genre() { Id = 1,
                Name = "Programming" });
            defaultGenres.Add(new Genre() { Id = 2,
                Name = "Fantasy" });
            defaultGenres.Add(new Genre() { Id = 3,
                Name = "Novel" });

            defaultBooks.Add(new Book() { Id = 1, Name = "Pro ASP.NET Core MVC 2",
                Author = "Adam Freeman", PublishYear = 2017, Publisher = "Apress",
                GenreId = 1
            });
            defaultBooks.Add(new Book() { Id = 2, Name = "Programming ASP.NET Core",
                Author = "Dino Esposito", PublishYear = 2018,
                Publisher = "Microsoft Press", GenreId = 1
            });
            defaultBooks.Add(new Book() { Id = 3, Author = "Lois Mai Chan",
                Name = "Cataloging and Classification: An Introduction",
                PublishYear = 2007, Publisher = "Scarecrow Press",
                GenreId = 3
            });
            #endregion

            context.Books.AddRange(defaultBooks);
            context.Genres.AddRange(defaultGenres);

            base.Seed(context);
        }
    }
}