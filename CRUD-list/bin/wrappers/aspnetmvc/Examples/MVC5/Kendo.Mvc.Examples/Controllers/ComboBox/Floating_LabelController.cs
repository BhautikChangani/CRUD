using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ComboBoxController : Controller
    {
        [Demo]
        public ActionResult Floating_Label()
        {
            return View();
        }
        public JsonResult FloatingLabel_GetProducts()
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