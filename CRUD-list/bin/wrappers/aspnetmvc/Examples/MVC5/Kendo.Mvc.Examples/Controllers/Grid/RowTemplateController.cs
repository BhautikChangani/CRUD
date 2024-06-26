using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult RowTemplate()
        {
            return View();
        }

        public ActionResult RowTemplate_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToList().ToDataSourceResult(request));
        }
    }
}