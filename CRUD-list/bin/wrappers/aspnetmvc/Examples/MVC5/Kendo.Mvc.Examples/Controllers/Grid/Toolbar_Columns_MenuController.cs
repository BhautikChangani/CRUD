using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Toolbar_Columns_Menu()
        {
            return View();
        }
        public ActionResult ToolbarColumnsMenu_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}