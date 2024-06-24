using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public ActionResult Remote_Binding_Orders_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetOrders().ToDataSourceResult(request));
        }
    }
}