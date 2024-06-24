using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class SalesPerformersModel
    {
        public SalesPerformersModel(string salesPerson, int salesAmount)
        {
            SalesPerson = salesPerson;
            SalesAmount = salesAmount;
        }

        public string SalesPerson { get; set; }
        public int SalesAmount { get; set; }
    }
}