namespace Kendo.Mvc.Examples.Controllers
{
    using Kendo.Mvc.Examples.Models;
    using System.Linq;
    using System.Web.Mvc;

    public partial class ComboBoxController : Controller
    {
        [Demo]
        public ActionResult ServerFiltering()
        {
            return View();
        }

        public JsonResult ServerFiltering_GetProducts(string text)
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

            if (!string.IsNullOrEmpty(text))
            {
                products = products.Where(p => p.ProductName.Contains(text));
            }

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}