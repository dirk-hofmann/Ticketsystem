using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
        public Ticket Ticket { get; set; }
    }
}