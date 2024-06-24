using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListViewController : Controller
    {
        [Demo]
        public ActionResult Local_Data_Binding()
        {
            var employees = GetEmployees();
            return View(employees);
        }

        private IEnumerable<EmployeeViewModel> GetEmployees()
        {
            using (var northwind = new DemoDBContext())
            {
                return northwind.Employees
                    .Select(employee =>
                        new EmployeeViewModel
                        {
                            EmployeeID = employee.EmployeeID,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Country = employee.Country,
                            City = employee.City,
                            Notes = employee.Notes,
                            Title = employee.Title,
                            Address = employee.Address,
                            HomePhone = employee.HomePhone
                        }
                    )
                    .ToList();
            };
        }
    }
}