using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : Controller
    {
        [Demo]
        public ActionResult Layout()
        {
            return View(new FormOrderViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                ShipCountry = "France",
                City = "Strasbourg",
                Address = ""
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Layout(FormOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Layout";
                return View("Success");
            }
        }
    }
}