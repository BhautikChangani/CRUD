namespace Kendo.Mvc.Examples.Controllers
{
    using Kendo.Mvc.Examples.Models;
    using System.Linq;
    using System.Web.Mvc;

    public partial class DropDownListController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Overview_Get_Categories()
        {
            var northwind = new DemoDBContext();

            return Json(northwind.Categories.Select(c => new { CategoryId = c.CategoryID, CategoryName = c.CategoryName }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Overview_GetTerritories()
        {
            var northwind = new DemoDBContext();
            var territories = northwind.Territories.Select(territory => new TerritoryViewModel
            {
                TerritoryID = territory.TerritoryID,
                TerritoryDescription = territory.TerritoryDescription
            }).ToList();

            territories = territories
                .GroupBy(g => g.TerritoryDescription)
                .Select(s => s.First())
                .ToList();

            return Json(territories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Overview_Get_Products(int? categories)
        {
            var northwind = new DemoDBContext();
            var products = northwind.Products.AsQueryable();

            if (categories != null)
            {
                products = products.Where(p => p.CategoryID == categories);
            }

            return Json(products.Select(p => new { ProductID = p.ProductID, ProductName = p.ProductName, SupplierCountry = p.Supplier.Country }), JsonRequestBehavior.AllowGet);
        }

    }
}