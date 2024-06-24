using System.Web.Mvc;
using System.Linq;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownTreeController : Controller
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public JsonResult Remote_Data_Binding_Get_Employees(int? id)
        {
            var dataContext = new DemoDBContext();

            var employees = dataContext.Employees
                                        .Where(x => id.HasValue ? x.ReportsTo == id : x.ReportsTo == null)
                                        .Select(x => new {
                                            id = x.EmployeeID,
                                            Name = x.FirstName + " " + x.LastName,
                                            hasChildren = dataContext.Employees.Any(e => e.ReportsTo == x.EmployeeID)
                                        });

            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}