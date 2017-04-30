using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public Company Company { get; set; }
        // Editors of this project
        public virtual List<ApplicationUser> Editors { get; set; }
        public string Title { get; set; }
        public virtual List<Ticket> Tickets { get; set; }
        public DateTime CreationDate { get; set; }
    }
}