using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiColumnComboBoxController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Overview_Customers_Read()
        {
            return Json(Overview_GetCustomers(), JsonRequestBehavior.AllowGet);
        }

        private IEnumerable<CustomerViewModel> Overview_GetCustomers()
        {
            var northwind = new DemoDBContext();
            return northwind.Customers.Select(customer => new CustomerViewModel
            {
                CustomerID = customer.CustomerID,
                CompanyName = customer.CompanyName,
                ContactName = customer.ContactName,
                ContactTitle = customer.ContactTitle,
                Address = customer.Address,
                City = customer.City,
                Region = customer.Region,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                Fax = customer.Fax,
                Bool = customer.Bool
            }).ToList();
        }
    }
}