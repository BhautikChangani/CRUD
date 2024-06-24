using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListBoxController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }

        public ActionResult Keyboard_Navigation_GetProducts()
        {
            var northwind = new DemoDBContext();

            var products = northwind.Products.Select(product => new ProductViewModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice ?? 0,
                UnitsInStock = product.UnitsInStock ?? 0,
                UnitsOnOrder = product.UnitsOnOrder ?? 0,
                Discontinued = product.Discontinued,
                LastSupply = DateTime.Today
            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}
