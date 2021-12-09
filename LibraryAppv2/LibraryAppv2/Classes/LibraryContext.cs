using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppv2
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() 
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SSC3ITL\SQLEXPRESS;Database=Library;Trusted_Connection=True;");// Где "DESKTOP-SSC3ITL\SQLEXPRESS" Написать имя своего сервера
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var authorEn = modelBuilder.Entity<Author>();
            authorEn.HasKey(c => c.Id);

            var bookEn = modelBuilder.Entity<Book>();
            bookEn.HasKey(c => c.Id);
            bookEn.HasOne(b => b.Author).WithMany(b => b.Books).HasForeignKey("AuthorId").IsRequired();
            bookEn.HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey("PublisherId").IsRequired();
            bookEn.HasOne(b => b.Genre).WithMany(b => b.Books).HasForeignKey("GenreId").IsRequired();

            var IssuesEn = modelBuilder.Entity<BookIssue>();
            IssuesEn.HasKey(c => c.Id);
            IssuesEn.HasOne(b => b.Client).WithMany(b => b.BookIssues).HasForeignKey("ClientId").IsRequired();
            IssuesEn.HasOne(b => b.Book).WithMany(b => b.BookIssues).HasForeignKey("BookId").IsRequired();

            var clientEn = modelBuilder.Entity<Client>();
            clientEn.HasKey(c => c.Id);

            var debtorsEn = modelBuilder.Entity<Debtors>();
            debtorsEn.HasOne(b => b.Client).WithMany(b => b.Debtors).HasForeignKey("ClientId").IsRequired().OnDelete(DeleteBehavior.NoAction);
            debtorsEn.HasOne(b => b.BookIssue).WithMany(b => b.Debtors).HasForeignKey("IssueId").IsRequired();

            var genre = modelBuilder.Entity<Genre>();
            genre.HasKey(c => c.Id);

            modelBuilder.Entity<Publisher>().HasKey(c => c.Id);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookIssue> BookIssue { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Debtors> Debtor { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

    }
}
