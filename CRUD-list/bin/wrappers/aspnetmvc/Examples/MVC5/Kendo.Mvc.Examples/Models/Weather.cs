using System;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Models
{
    public partial class Weather
    {
        [Key]
        public int ID { get; set; }

        public string Station { get; set; }

        public System.DateTime Date { get; set; }

        public decimal TMax { get; set; }

        public decimal TMin { get; set; }

        public decimal Wind { get; set; }

        public Nullable<decimal> Gust { get; set; }

        public decimal Rain { get; set; }

        public Nullable<decimal> Snow { get; set; }

        public string Events { get; set; }
    }
}