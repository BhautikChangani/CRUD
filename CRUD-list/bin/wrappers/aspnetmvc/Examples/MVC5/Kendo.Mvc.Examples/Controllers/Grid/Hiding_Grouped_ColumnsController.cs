using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Hiding_Grouped_Columns()
        {
            return View();
        }
        
        public ActionResult HidingGroupedColumns_Read([DataSourceRequest] DataSourceRequest request)
        {
            var products = productService.Read();

            return Json(products.ToDataSourceResult(request));
        }
    }
}