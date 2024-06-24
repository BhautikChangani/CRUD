using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Country
    {
        public Country()
        {
            this.DetailProducts = new HashSet<DetailProduct>();
        }

        [Key]
        public byte CountryID { get; set; }

        public string CountryNameShort { get; set; }

        public string CountryNameLong { get; set; }

        [InverseProperty(nameof(DetailProduct.Country))]
        public virtual ICollection<DetailProduct> DetailProducts { get; set; }
    }
}