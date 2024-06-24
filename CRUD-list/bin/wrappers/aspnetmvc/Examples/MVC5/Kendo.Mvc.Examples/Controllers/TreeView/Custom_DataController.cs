using System.Web.Mvc;
using System.Linq;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : Controller
    {
        [Demo]
        public ActionResult Custom_Data()
        {
            return View();
        }

        public JsonResult Users(int? id)
        {
            var dataContext = new DemoDBContext();

            var employees = dataContext.Employees
                                        .Where(x => id.HasValue ? x.ReportsTo == id : x.ReportsTo == null)
                                        .Select(x => new {
                                            id = x.EmployeeID,
                                            Name = x.FirstName + " " + x.LastName,
                                            hasChildren = dataContext.Employees.Any(e => e.ReportsTo == x.EmployeeID),
                                            Username = x.FirstName.ToLower() + x.EmployeeID
                                        });

            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}