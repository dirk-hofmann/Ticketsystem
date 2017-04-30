using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime CreationDate { get; set; }
        public byte[] Payload { get; set; }
    }
}