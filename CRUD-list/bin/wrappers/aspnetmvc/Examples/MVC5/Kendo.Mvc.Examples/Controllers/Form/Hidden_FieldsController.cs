using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : Controller
    {
        [Demo]
        public ActionResult Hidden_Fields()
        {
            return View(new UserViewModel()
            {
                UserID = 1,
                UserName = "johny",
                Password = "123456",
                Email = "john.doe@email.com"
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Hidden_Fields(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                TempData["View"] = "Index";
                return View("Success");
            }
        }

    }
}
