﻿using LibraryAppv2.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2.Repository.Classes_For_Interfaces
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(LibraryContext context) : base(context) { } 
        public LibraryContext LibraryContext
        {
            get { return Context as LibraryContext; }
        }
    }
}
