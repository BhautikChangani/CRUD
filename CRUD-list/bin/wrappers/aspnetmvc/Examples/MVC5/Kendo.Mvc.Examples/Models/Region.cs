using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territory>();
        }

        [Key]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }

        [InverseProperty(nameof(Territory.Region))]
        public virtual ICollection<Territory> Territories { get; set; }
    }
}