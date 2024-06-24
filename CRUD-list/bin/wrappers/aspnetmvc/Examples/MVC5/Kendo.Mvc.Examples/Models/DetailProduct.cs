using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class DetailProduct
    {
        [Key]
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }

        public Nullable<short> UnitsInStock { get; set; }

        public string QuantityPerUnit { get; set; }

        public bool Discontinued { get; set; }

        public Nullable<int> UnitsOnOrder { get; set; }

        public Nullable<int> CategoryID { get; set; }

        public Nullable<byte> CountryID { get; set; }

        public Nullable<byte> CustomerRating { get; set; }

        public Nullable<int> TargetSales { get; set; }

        public Nullable<System.DateTime> LastSupply { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Models.Category.DetailProducts))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(CountryID))]
        [InverseProperty(nameof(Models.Country.DetailProducts))]
        public virtual Country Country { get; set; }
    }
}