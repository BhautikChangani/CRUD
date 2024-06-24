using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Stock
    {
        [Key]
        public int ID { get; set; }

        public string Symbol { get; set; }

        public System.DateTime Date { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }

        public decimal Close { get; set; }

        public long Volume { get; set; }
    }
}