using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryAppv2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppv2.Repository.Classes_For_Interfaces
{
    class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext context) : base(context) {}
        public LibraryContext LibraryContext
        {
            get { return Context as LibraryContext; }
        }
    }
}
