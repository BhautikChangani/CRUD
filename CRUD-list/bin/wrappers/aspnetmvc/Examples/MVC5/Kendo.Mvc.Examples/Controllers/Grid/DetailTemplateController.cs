using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult DetailTemplate()
        {
            return View();
        }

        public ActionResult DetailTemplate_HierarchyBinding_Employees([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        public ActionResult DetailTemplate_HierarchyBinding_Orders(int employeeID, [DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders()
                .Where(order => order.EmployeeID == employeeID)
                .ToDataSourceResult(request));
        }
    }
}