using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }

        [Key]
        public int ShipperID { get; set; }

        public string CompanyName { get; set; }

        public string Phone { get; set; }

        [InverseProperty(nameof(Order.Shipper))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}