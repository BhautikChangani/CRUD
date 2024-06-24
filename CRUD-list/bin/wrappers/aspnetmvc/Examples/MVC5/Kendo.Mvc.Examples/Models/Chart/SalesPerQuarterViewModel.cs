using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class SalesPerQuarterViewModel
    {
        public string Period { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}