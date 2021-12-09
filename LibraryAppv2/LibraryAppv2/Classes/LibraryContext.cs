﻿using System;
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
            Database.EnsureDeleted();
            Database.EnsureCreated(); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SSC3ITL\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var authorEn = modelBuilder.Entity<Author>();
            authorEn.HasKey();

            var bookEn = modelBuilder.Entity<Book>();
            bookEn.HasKey();
            bookEn.HasOne(b => b.Author).WithMany(b => b.Books).HasForeignKey("AuthorId").IsRequired();
            bookEn.HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey("PublisherId").IsRequired();
            bookEn.HasOne(b => b.Genre).WithMany(b => b.Books).HasForeignKey("GenreId").IsRequired();

            var 


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Debtors> Debtors { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
