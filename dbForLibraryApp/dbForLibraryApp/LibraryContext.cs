using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Sql;

namespace dbForLibraryApp
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("DefaultConnection") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorAndBook> AuthorAndBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
    }
}
