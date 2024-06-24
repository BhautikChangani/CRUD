using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Drag_Drop()
        {
            return View();
        }

        public ActionResult Drag_Drop_Active_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().Where(p => p.Discontinued == true).ToDataSourceResult(request));
        }

        public ActionResult Drag_Drop_Inactive_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().Where(p => p.Discontinued != true).ToDataSourceResult(request));
        }
    }
}