using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : Controller
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }


        public JsonResult GetCategories()
        {
            var northwind = new DemoDBContext();

            var result = northwind.Categories.Select((category) => 
                new
                {
                    Name = category.CategoryName,
                    Products = northwind.Products
                        .Where((product) => product.CategoryID == category.CategoryID)
                        .Select((product)=> new { Name = product.ProductName })
                }
            );

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
