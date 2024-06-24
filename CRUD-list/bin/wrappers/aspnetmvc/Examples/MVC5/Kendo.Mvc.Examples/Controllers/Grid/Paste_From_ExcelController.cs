using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Paste_From_Excel()
        {
            return View();
        }

        public ActionResult Paste_From_Excel_Orders_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}