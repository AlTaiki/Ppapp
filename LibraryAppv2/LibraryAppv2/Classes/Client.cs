using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppv2
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Phone { get; set; }
        public virtual ICollection<BookIssue> BookIssues { get; set; }
        public virtual ICollection<Debtors> Debtors { get; set; }
    }
}
