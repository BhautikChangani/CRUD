using System.Web.Mvc;
using System.Linq;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownTreeController : Controller
    {
        [Demo]
        public ActionResult Adaptive_Mode()
        {
            return View();
        }

        public JsonResult AdaptiveMode_GetEmployees(int? id)
        {
            var dataContext = new DemoDBContext();

            var employees = from e in dataContext.Employees
                            where (id.HasValue ? e.ReportsTo == id : e.ReportsTo == null)
                            select new {
                                id = e.EmployeeID,
                                Name = e.FirstName + " " + e.LastName,
                                hasChildren = dataContext.Employees.Any(x => x.ReportsTo == e.EmployeeID)
                            };

            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}