using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2
{
    public class BookIssue
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Client Client;
        public Book Book;
        public virtual ICollection<Debtor> Debtors { get; set; }
    }
}
