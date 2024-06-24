using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FormController : Controller
    {
        [Demo]
        public ActionResult Basic_Usage()
        {
            return View(new UserViewModel()
            {
                Email = "john.doe@email.com"
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Basic_Usage(UserViewModel model)
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