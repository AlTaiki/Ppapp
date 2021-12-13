using LibraryAppv2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookIssueRepository BookIssues { get; }
        IBookRepository Books { get; }
        IClientRepository Clients { get; }
        IDebtorRepository Debtors { get; }
        IGenreRepository Genres { get; }
        IPublisherRepository Publishers { get; }
        int Complete();
    }
}
