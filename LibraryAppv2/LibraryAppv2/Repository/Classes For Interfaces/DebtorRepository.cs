using LibraryAppv2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2.Repository.Classes_For_Interfaces
{
    public class DebtorRepository : Repository<Debtor>, IDebtorRepository 
    {
        public DebtorRepository(LibraryContext context) : base(context) { }
        public LibraryContext LibraryContext
        {
            get { return Context as LibraryContext; }
        }
    }
}
