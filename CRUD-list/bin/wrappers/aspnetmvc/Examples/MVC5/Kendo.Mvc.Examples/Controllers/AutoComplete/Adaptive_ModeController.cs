namespace Kendo.Mvc.Examples.Controllers
{
    using Kendo.Mvc.Examples.Models;
    using System.Linq;
    using System.Web.Mvc;

    public partial class AutoCompleteController : Controller
    {
        [Demo]
        public ActionResult Adaptive_Mode()
        {
            return View();
        }

        public JsonResult AdaptiveMode_GetProducts()
        {
            var northwind = new DemoDBContext();


            var products = northwind.Products.Select(product => new ProductViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
                UnitsInStock = product.UnitsInStock ?? 0,
                UnitsOnOrder = product.UnitsOnOrder ?? 0,
                Discontinued = product.Discontinued
            });

            return Json(products.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}