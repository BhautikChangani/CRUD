using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Chart;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ChartsController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}
