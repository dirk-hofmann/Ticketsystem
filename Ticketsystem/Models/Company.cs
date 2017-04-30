using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticketsystem.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string StreetAdress { get; set; }
        public string Postcode { get; set; }
        public string City { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
    }
}