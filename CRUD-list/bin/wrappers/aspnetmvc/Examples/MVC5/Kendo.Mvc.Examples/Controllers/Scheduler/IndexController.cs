namespace Kendo.Mvc.Examples.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.Examples.Models.Scheduler;

    public partial class SchedulerController : Controller
    {
        private SchedulerTaskService taskService;
        private SchedulerMeetingService meetingService;


        public SchedulerController()
        {
            this.taskService = new SchedulerTaskService();
            this.meetingService = new SchedulerMeetingService();
        }

        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Overview_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetTasks().ToDataSourceResult(request));
        }

        public virtual JsonResult Overview_Destroy([DataSourceRequest] DataSourceRequest request, Activity task)
        {
            if (ModelState.IsValid)
            {
                var newTasks = GetTasks().Where(t => t.ID != task.ID);
                Session["tasks"] = newTasks;
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Overview_Create([DataSourceRequest] DataSourceRequest request, Activity task)
        {
            if (ModelState.IsValid)
            {
                task.ID = GetTasks().Last().ID + 1;
                var newTasks = GetTasks();
                newTasks.Add(task);
                Session["tasks"] = newTasks;
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Overview_Update([DataSourceRequest] DataSourceRequest request, Activity task)
        {
            if (ModelState.IsValid)
            {
                var newTasks = GetTasks().Where(t => t.ID != task.ID).ToList();
                newTasks.Add(task);
                Session["tasks"] = newTasks;
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public IList<Activity> GetTasks()
        {
            IList<Activity> schedulerTasks = new List<Activity>()
            {
                new Activity { ID = 1, Title = "AP Physics", Image = "physics.png", Start = new DateTime(2020,10,5,8,00,00), End= new DateTime(2020,10,5,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=MO;WKST=SU", Attendee = 1 },
                new Activity { ID = 2, Title = "History", Image = "history.png", Start = new DateTime(2020,10,5,9,00,00), End= new DateTime(2020,10,5,10,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=9;BYDAY=MO,WE,TH,FR;WKST=SU", Attendee = 1 },
                new Activity { ID = 3, Title = "Art", Image = "art.png", Start = new DateTime(2020,10,5,9,00,00), End= new DateTime(2020,10,5,10,00,00), Attendee = 2 },
                new Activity { ID = 4, Title = "Spanish", Image = "spanish.png", Start = new DateTime(2020,10,5,10,00,00), End= new DateTime(2020,10,5,11,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=MO,TH;WKST=SU", Attendee = 1 },
                new Activity { ID = 5, Title = "Home Ec", Image = "home-ec.png", Start = new DateTime(2020,10,5,10,00,00), End= new DateTime(2020,10,5,11,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=MO,TH;WKST=SU", Attendee = 2 },
                new Activity { ID = 6, Title = "AP Math", Image = "math.png", Start = new DateTime(2020,10,5,11,00,00), End= new DateTime(2020,10,5,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=MO,TH;WKST=SU", Attendee = 1 },
                new Activity { ID = 7, Title = "AP Econ", Image = "econ.png", Start = new DateTime(2020,10,5,11,00,00), End= new DateTime(2020,10,5,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=MO,TH;WKST=SU", Attendee = 2 },
                new Activity { ID = 8, Title = "Photography Club Meeting", Image = "photography.png", Start = new DateTime(2020,10,5,14,00,00), End= new DateTime(2020,10,5,15,30,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=MO;WKST=SU", Attendee = 2 },
                new Activity { ID = 9, Title = "Tennis Practice", Image = "tennis.png", Start = new DateTime(2020,10,5,15,30,00), End= new DateTime(2020,10,5,16,30,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=MO;WKST=SU", Attendee = 1 },
                new Activity { ID = 10, Title = "French", Image = "french.png", Start = new DateTime(2020,10,5,8,00,00), End= new DateTime(2020,10,5,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TU;WKST=SU", Attendee = 2 },
                new Activity { ID = 11, Title = "Gym", Image = "gym.png", Start = new DateTime(2020,10,6,9,00,00), End= new DateTime(2020,10,6,10,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=TU;WKST=SU", Attendee = 1 },
                new Activity { ID = 12, Title = "English", Image = "english.png", Start = new DateTime(2020,10,6,9,00,00), End= new DateTime(2020,10,6,10,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TU;WKST=SU", Attendee = 2 },
                new Activity { ID = 13, Title = "English", Image = "english.png", Start = new DateTime(2020,10,6,10,00,00), End= new DateTime(2020,10,6,11,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=12;BYDAY=TU,FR;WKST=SU", Attendee = 1 },
                new Activity { ID = 14, Title = "History", Image = "history.png", Start = new DateTime(2020,10,6,11,00,00), End= new DateTime(2020,10,6,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TU;WKST=SU", Attendee = 1 },
                new Activity { ID = 15, Title = "Gym", Image = "gym.png", Start = new DateTime(2020,10,6,11,00,00), End= new DateTime(2020,10,6,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TU;WKST=SU", Attendee = 2 },
                new Activity { ID = 16, Title = "English", Image = "english.png", Start = new DateTime(2020,10,6,8,00,00), End= new DateTime(2020,10,6,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=WE;WKST=SU", Attendee = 1 },
                new Activity { ID = 17, Title = "School Choir Practice", Image = "choir.png", Start = new DateTime(2020,10,6,14,30,00), End= new DateTime(2020,10,6,15,30,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TU;WKST=SU", Attendee = 2 },
                new Activity { ID = 18, Title = "Art", Image = "art.png", Start = new DateTime(2020,10,7,8,00,00), End= new DateTime(2020,10,7,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=WE;WKST=SU", Attendee = 2 },
                new Activity { ID = 19, Title = "French", Image = "french.png", Start = new DateTime(2020,10,7,9,00,00), End= new DateTime(2020,10,7,10,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=10;BYDAY=WE,FR;WKST=SU", Attendee = 2 },
                new Activity { ID = 20, Title = "Gym", Image = "gym.png", Start = new DateTime(2020,10,7,10,00,00), End= new DateTime(2020,10,7,11,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=WE;WKST=SU", Attendee = 1 },
                new Activity { ID = 21, Title = "English", Image = "english.png", Start = new DateTime(2020,10,7,10,00,00), End= new DateTime(2020,10,7,11,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=WE;WKST=SU", Attendee = 2 },
                new Activity { ID = 22, Title = "AP Physics", Image = "physics.png", Start = new DateTime(2020,10,7,11,00,00), End= new DateTime(2020,10,7,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=WE;WKST=SU", Attendee = 1 },
                new Activity { ID = 23, Title = "Spanish Club", Image = "spanish.png", Start = new DateTime(2020,10,7,13,30,00), End= new DateTime(2020,10,7,15,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=WE;WKST=SU", Attendee = 1 },
                new Activity { ID = 24, Title = "AP CompSci", Image = "computer-science.png", Start = new DateTime(2020,10,8,8,00,00), End= new DateTime(2020,10,8,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TH;WKST=SU", Attendee = 1 },
                new Activity { ID = 25, Title = "Gym", Image = "gym.png", Start = new DateTime(2020,10,8,9,00,00), End= new DateTime(2020,10,8,10,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TH;WKST=SU", Attendee = 2 },
                new Activity { ID = 26, Title = "School Paper Meeting", Image = "newspaper.png", Start = new DateTime(2020,10,8,14,00,00), End= new DateTime(2020,10,8,15,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TH;WKST=SU", Attendee = 2 },
                new Activity { ID = 27, Title = "Tennis Practice", Image = "tennis.png", Start = new DateTime(2020,10,8,15,00,00), End= new DateTime(2020,10,8,16,30,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=TH;WKST=SU", Attendee = 2 },
                new Activity { ID = 28, Title = "English", Image = "english.png", Start = new DateTime(2020,10,9,8,00,00), End= new DateTime(2020,10,9,9,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=FR;WKST=SU", Attendee = 2 },
                new Activity { ID = 29, Title = "AP CompSci", Image = "computer-science.png", Start = new DateTime(2020,10,9,11,00,00), End= new DateTime(2020,10,9,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=FR;WKST=SU", Attendee = 1 },
                new Activity { ID = 30, Title = "Art", Image = "art.png", Start = new DateTime(2020,10,9,11,00,00), End= new DateTime(2020,10,9,12,00,00), RecurrenceRule="FREQ=WEEKLY;COUNT=5;BYDAY=FR;WKST=SU", Attendee = 2 },
            };

            return schedulerTasks;
        }

        protected override void Dispose(bool disposing)
        {
            taskService.Dispose();
            meetingService.Dispose();
            base.Dispose(disposing);
        }
    }
}
