using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloristWebsite.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Bouquets = new HashSet<Bouquets>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }

        public virtual ICollection<Bouquets> Bouquets { get; set; }
    }
}
