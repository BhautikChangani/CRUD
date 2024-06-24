using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
            this.DetailProducts = new HashSet<DetailProduct>();
        }

        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }

        [InverseProperty(nameof(DetailProduct.Category))]
        public virtual ICollection<DetailProduct> DetailProducts { get; set; }
    }
}