using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FilterController : Controller
    {
        [Demo]
        public ActionResult Persist_State()
        {
            return View();
        }
    }
}
