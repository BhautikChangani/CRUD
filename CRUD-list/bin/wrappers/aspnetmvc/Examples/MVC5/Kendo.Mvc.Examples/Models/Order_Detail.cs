using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kendo.Mvc.Examples.Models
{
    public partial class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey(nameof(OrderID))]
        [InverseProperty(nameof(Models.Order.OrderDetails))]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(ProductID))]
        [InverseProperty(nameof(Models.Product.OrderDetails))]
        public virtual Product Product { get; set; }
    }
}