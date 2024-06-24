using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Form;
using Kendo.Mvc.UI;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : Controller
    {
        [Demo]
        public ActionResult Validation()
        {
            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "John",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456",
                ConfirmPassword = "123456",
                Height = 180,
                DateOfBirth = new DateTime(2020, 5, 8),
                HireDate = new DateTime(2020, 1, 1),
                RetireDate = new DateTime(2020, 1, 1),
                Agree = true
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Validation(UserViewModel model)
        {
            int compareDates = Nullable.Compare<DateTime>(model.HireDate, model.RetireDate);

            if (model.FirstName == model.LastName)
            {
                ModelState.AddModelError("LastName", "LastName must be different than First Name.");
            }
            if (compareDates >= 0)
            {
                ModelState.AddModelError("RetireDate", "Retire Date must be after Hire Date.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Validation";
                return View("Success");
            }
        }
    }
}
