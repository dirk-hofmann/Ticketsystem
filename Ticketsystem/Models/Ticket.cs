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

        public virtual List<Message> Messages { get; set; }

        public TimeSpan EstimatedExpense { get; set; }

        public TicketStatus Status { get; set; }

        // Constructor
        public Ticket()
        {
            Status = TicketStatus.Created;
            CreationDate = DateTime.Now;
        }
    }

    public enum TicketStatus
    {
        Created,
        Ordered,
        InProgress,
        WaitingForResponse,
        Closed
    };

}