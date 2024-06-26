namespace Kendo.Mvc.Examples.Controllers
{
    using Kendo.Mvc.Examples.Models;
    using System.Linq;
    using System.Web.Mvc;

    public partial class ComboBoxController : Controller
    {
        [Demo]
        public ActionResult CascadingComboBox()
        {
            return View();
        }

        public JsonResult Cascading_Get_Categories()
        {
            var northwind = new DemoDBContext();

            return Json(northwind.Categories.Select(c => new { CategoryId = c.CategoryID, CategoryName = c.CategoryName }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cascading_Get_Products(int? categories, string productFilter)
        {
            var northwind = new DemoDBContext();
            var products = northwind.Products.AsQueryable();

            if (categories != null)
            {
                products = products.Where(p => p.CategoryID == categories);
            }

            if (!string.IsNullOrEmpty(productFilter))
            {
                products = products.Where(p => p.ProductName.Contains(productFilter));
            }

            return Json(products.Select(p => new { ProductID = p.ProductID, ProductName = p.ProductName }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Cascading_Get_Orders(int? products, string orderFilter)
        {
            var northwind = new DemoDBContext();
            var orders = northwind.OrderDetails.AsQueryable();

            if (products != null)
            {
                orders = orders.Where(o => o.ProductID == products);
            }

            if (!string.IsNullOrEmpty(orderFilter))
            {
                orders = orders.Where(o => o.Order.ShipCity.Contains(orderFilter));
            }

            return Json(orders.Select(o => new { OrderID = o.OrderID, ShipCity = o.Order.ShipCity }), JsonRequestBehavior.AllowGet);
        }
    }
}