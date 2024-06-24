using Kendo.Mvc.Examples.Models;
using System;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TimeDurationPickerController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            TimeDurationPickerViewModel timeDurationOverviewModel = new TimeDurationPickerViewModel()
            {
                Title = "Modern UI Made Easy",
                Start = DateTime.Now.AddMinutes(15),
                Duration = 5400000,
                Banner = 900000
            };

            return View(timeDurationOverviewModel);
        }
    }
}