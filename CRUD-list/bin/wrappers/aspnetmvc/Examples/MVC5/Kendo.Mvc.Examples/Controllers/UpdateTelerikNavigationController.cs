using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public class UpdateTelerikNavigationController : Controller
    {
        [Home]
        public ActionResult Index()
        {
            return Json("Sorry, this page does not exist.", JsonRequestBehavior.AllowGet);
        }
    }
}
