using System.ComponentModel.DataAnnotations.Schema;

namespace Task7_RESTful.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Publisher { get; set; }

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }
}