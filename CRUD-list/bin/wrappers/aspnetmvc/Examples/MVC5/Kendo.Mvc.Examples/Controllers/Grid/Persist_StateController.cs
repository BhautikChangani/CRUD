using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Persist_State()
        {
            return View();
        }

        public ActionResult PersistState_Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request));
        }
    }
}