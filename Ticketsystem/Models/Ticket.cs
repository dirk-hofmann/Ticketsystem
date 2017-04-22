using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Ticket
    {
        // Id of the ticket
        public int TicketId { get; set; }

        // The project that the ticket belongs to
        public Project Project { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        // Constructor
        public Ticket()
        {
            CreationDate = DateTime.Now;
        }
    }
}