using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class CustomerDemographic
    {
        public CustomerDemographic()
        {
            this.Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }

        public string CustomerTypeID { get; set; }

        public string CustomerDesc { get; set; }

        [InverseProperty(nameof(Customer.CustomerDemographics))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}