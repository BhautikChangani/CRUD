using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListBoxController : Controller
    {
        [Demo]
        public ActionResult Events()
        {
            return View();
        }

        public JsonResult Events_GetCustomers()
        {
            var customers = new DemoDBContext().Customers.Select(customer => new CustomerViewModel
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
            });

            return Json(customers, JsonRequestBehavior.AllowGet);
        }
    }
}
