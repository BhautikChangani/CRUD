using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AppBarController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
    }
}
