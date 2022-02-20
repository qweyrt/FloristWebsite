using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloristWebsite.Models
{
    public partial class Bouquets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? CustomerId { get; set; }
        public int? RecipientId { get; set; }
        public int? BouquetMessageId { get; set; }

        public virtual BouquetsMessages BouquetMessage { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Recipients Recipient { get; set; }
    }
}
