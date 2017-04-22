using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}