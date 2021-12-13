using LibraryAppv2.Repository;
using LibraryAppv2.Repository.Classes_For_Interfaces;
using LibraryAppv2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public UnitOfWork(LibraryContext context)
        {
            _context = context;
            Authors = new AuthorRepository(_context);
            BookIssues = new BookIssueRepository(_context);
            Books = new BookRepository(_context);
            Clients = new ClientRepository(_context);
            Debtors = new DebtorRepository(_context);
            Genres = new GenreRepository(_context);
            Publishers = new PublisherRepository(_context);
        }
        public IAuthorRepository Authors { get; private set; }
        public IBookIssueRepository BookIssues { get; private set; }
        public IBookRepository Books { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IDebtorRepository Debtors { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IPublisherRepository Publishers { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
