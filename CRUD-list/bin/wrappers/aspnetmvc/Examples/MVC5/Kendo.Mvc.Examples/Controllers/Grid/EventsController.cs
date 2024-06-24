using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Events_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}
