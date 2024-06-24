using Kendo.Mvc.Examples.Models;
using System;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TimeDurationPickerController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            return View();
        }
    }
}