namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Examples.Models.Scheduler;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using System;

    public partial class SchedulerController : Controller
    {
        [Demo]
        public ActionResult Import_Export_Ical()
        {
            return View();
        }
    }
}
