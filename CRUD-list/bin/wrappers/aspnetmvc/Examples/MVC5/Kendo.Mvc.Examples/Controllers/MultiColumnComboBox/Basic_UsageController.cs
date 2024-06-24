namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Kendo.Mvc.Examples.Models;

    public partial class MultiColumnComboBoxController : Controller
    {
        [Demo]
        public ActionResult Basic_Usage()
        {
            ViewData["products"] = GetProducts();
            return View();
        }
        private static IEnumerable<ProductViewModel> GetProducts()
        {
            var products = new List<ProductViewModel>()
            {
                new ProductViewModel { ProductID = 1, ProductName = "Chai" },
                new ProductViewModel { ProductID = 2, ProductName = "Chang" },
                new ProductViewModel { ProductID = 3, ProductName = "Aniseed Syrup" },
                new ProductViewModel { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning" },
                new ProductViewModel { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix" },
                new ProductViewModel { ProductID = 6, ProductName = "Grandma's Boysenberry Spread" },
                new ProductViewModel { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears" },
                new ProductViewModel { ProductID = 8, ProductName = "Northwoods Cranberry Sauce" },
                new ProductViewModel { ProductID = 9, ProductName = "Mishi Kobe Niku" },
                new ProductViewModel { ProductID = 10, ProductName = "Ikura" },
            };

            return products;
        }
    }
}