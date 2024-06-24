using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Sticky_Columns()
        {
            return View();
        }
        public ActionResult StickyColumns_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }

    }
}
