namespace Kendo.Mvc.Examples.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class ProductViewModelGridPopUp
    {
        [ScaffoldColumn(false)]
        public int ProductID
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Product name")]
        public string ProductName
        {
            get;
            set;
        }

        [Display(Name = "Unit price")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public decimal UnitPrice
        {
            get;
            set;
        }

        [Display(Name = "Units in stock")]
        [DataType("Integer")]
        [Range(0, int.MaxValue)]
        public int UnitsInStock
        {
            get;
            set;
        }

        public bool Discontinued
        {
            get;
            set;
        }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime LastSupply
        {
            get;
            set;
        }
    }
}