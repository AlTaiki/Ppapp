using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppv2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (LibraryContext db = new LibraryContext())
            {
                var books = (from Book in db.Book.Include(p => p.Author) where Book.AuthorId == 1 select Book);
            }
            
        }
    }
}
