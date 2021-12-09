using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppv2
{
    public class Debtors
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int IssueId { get; set; }
        public Client Client;
        public BookIssue BookIssue;
    }
}
