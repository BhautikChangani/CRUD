using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }

        public ActionResult Keyboard_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }
    }
}