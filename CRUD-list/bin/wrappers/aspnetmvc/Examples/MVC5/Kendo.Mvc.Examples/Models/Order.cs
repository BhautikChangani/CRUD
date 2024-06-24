using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> ShipperId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        [ForeignKey(nameof(CustomerID))]
        [InverseProperty(nameof(Models.Customer.Orders))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty(nameof(Models.Employee.Orders))]
        public virtual Employee Employee { get; set; }

        [InverseProperty(nameof(Models.OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [ForeignKey(nameof(ShipperId))]
        [InverseProperty(nameof(Models.Shipper.Orders))]
        public virtual Shipper Shipper { get; set; }
    }
}