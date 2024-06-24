using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Cell_Alignment()
        {
            return View();
        }

        public ActionResult CellAlignment_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}