using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Territory
    {
        public Territory()
        {
            this.Employees = new HashSet<Employee>();
        }

        [Key]
        public string TerritoryID { get; set; }

        public string TerritoryDescription { get; set; }

        public int RegionID { get; set; }

        [ForeignKey(nameof(RegionID))]
        [InverseProperty(nameof(Models.Region.Territories))]
        public virtual Region Region { get; set; }

        [InverseProperty(nameof(Models.Employee.Territories))]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}