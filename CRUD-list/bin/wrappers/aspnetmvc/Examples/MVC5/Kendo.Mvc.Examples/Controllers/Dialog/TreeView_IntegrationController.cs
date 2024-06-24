using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DialogController : Controller
    {
        [Demo]
        public ActionResult TreeView_Integration()
        {
            return View();
        }
        public JsonResult TreeView_Employees(int? id)
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
