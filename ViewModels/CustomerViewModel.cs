 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
