using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string ReleaseYear { get; set; }
        public int GenreId { get; set; }
        public Author Author;
        public Publisher Publisher;
        public Genre Genre;
    }
}
