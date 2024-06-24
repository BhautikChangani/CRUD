using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public class CompanyModel
    {
        public string CompanyName { get; set; }
        public decimal Sales { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
