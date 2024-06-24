using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class StockDataModel
    {
        public DateTime Date { get; set; }

        public decimal Close { get; set; }

        public long Volume { get; set; }

        public decimal Open { get; set; }

        public decimal High { get; set; }

        public decimal Low { get; set; }
    }
}