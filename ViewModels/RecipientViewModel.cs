using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.ViewModels
{
    public class RecipientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? Date { get; set; }

    }
}
