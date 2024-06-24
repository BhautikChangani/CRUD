using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Mobile_ListViewController : Controller
    {       
        public ActionResult Hierarchical_Databinding()
        {
            return View();
        }

        public JsonResult Employees(int? EmployeeId)
        {
            var dataContext = new DemoDBContext();

            var employees = dataContext.Employees
                                        .Where(x => EmployeeId.HasValue ? x.ReportsTo == EmployeeId : x.ReportsTo == null)
                                        .Select(x => new {
                                            id = x.EmployeeID,
                                            Name = x.FirstName + " " + x.LastName,
                                            hasChildren = dataContext.Employees.Any(e => e.ReportsTo == x.EmployeeID)
                                        });

            return Json(employees, JsonRequestBehavior.AllowGet);
        }
    }
}
