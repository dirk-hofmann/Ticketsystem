using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public ApplicationUser Booker { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime CreationDate { get; set; }
        public TimeSpan Expense { get; set; } 
    }
}