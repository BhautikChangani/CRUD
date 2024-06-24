using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Right_To_Left_Support()
        {
            return View();
        }

        public ActionResult Rtl_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}