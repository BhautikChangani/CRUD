using Kendo.Mvc.Examples.Models.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SchedulerController : Controller
    {
        [Demo]
        public ActionResult Ongoing_Events()
        {
            var vm = GetOngoingEventsTasks();

            return View(vm);
        }

        private IEnumerable<TaskViewModel> GetOngoingEventsTasks()
        {
            var schedule = new List<TaskViewModel> {
                new TaskViewModel(){ TaskID = 1, Title="Current Event", Start = DateTime.Now.AddHours(-1), End = DateTime.Now.AddHours(1) },
                new TaskViewModel(){ TaskID = 2, Title="Gym", Start = DateTime.Now.AddHours(2), End = DateTime.Now.AddHours(4) },
                new TaskViewModel(){ TaskID = 3, Title="Meet Alex", Start = DateTime.Now.AddHours(-3), End = DateTime.Now.AddHours(-1)},
                new TaskViewModel() { TaskID = 4, Title = "Cinema time", Start = DateTime.Now.AddDays(-1).AddHours(2), End = DateTime.Now.AddDays(-1).AddHours(5) },
                new TaskViewModel() { TaskID = 5, Title = "Meeting", Start = DateTime.Now.AddDays(1).AddHours(-2), End = DateTime.Now.AddDays(1).AddHours(-3) }
            };
            return schedule;
        }
    }
}