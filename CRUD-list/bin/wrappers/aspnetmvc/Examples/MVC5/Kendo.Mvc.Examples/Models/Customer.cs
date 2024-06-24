using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
            this.CustomerDemographics = new HashSet<CustomerDemographic>();
        }

        [Key]
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }

        public Nullable<bool> Bool { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }

        [InverseProperty(nameof(CustomerDemographic.Customers))]
        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}