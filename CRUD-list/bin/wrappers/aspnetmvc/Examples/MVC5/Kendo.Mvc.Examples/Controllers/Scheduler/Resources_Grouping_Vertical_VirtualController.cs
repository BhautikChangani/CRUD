namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Examples.Models.Scheduler;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public partial class SchedulerController : Controller
    {
        [Demo]
        public ActionResult Resources_Grouping_Vertical_Virtual()
        {
            return View();
        }
    }
}
