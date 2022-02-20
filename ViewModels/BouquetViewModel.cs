using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.ViewModels
{
    public class BouquetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public int? RecipientId { get; set; }
        public string RecipientName { get; set; }
        public int? BouquetMessageId { get; set; }
        public string BouquetMessageMessage { get; set; }


    }
}
