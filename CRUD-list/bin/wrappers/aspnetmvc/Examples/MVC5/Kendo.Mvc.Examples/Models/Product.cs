using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Product
    {
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<short> UnitsInStock { get; set; }
        public Nullable<short> UnitsOnOrder { get; set; }
        public Nullable<short> ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Models.Category.Products))]
        public virtual Category Category { get; set; }

        [InverseProperty(nameof(OrderDetail.Product))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [ForeignKey(nameof(SupplierID))]
        [InverseProperty(nameof(Models.Supplier.Products))]
        public virtual Supplier Supplier { get; set; }
    }
}