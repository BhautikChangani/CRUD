namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.Examples.Models.Scheduler;
    using System.Threading;
    using System.Globalization;

    public partial class SchedulerController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request["culture"]))
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(requestContext.HttpContext.Request["culture"]);
            }
            base.Initialize(requestContext);
        }

        [Demo]
        public ActionResult Globalization()
        {
            return View();
        }

        public virtual JsonResult Globalization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(meetingService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Globalization_Destroy([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Delete(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Globalization_Create([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Insert(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Globalization_Update([DataSourceRequest] DataSourceRequest request, MeetingViewModel meeting)
        {
            if (ModelState.IsValid)
            {
                meetingService.Update(meeting, ModelState);
            }

            return Json(new[] { meeting }.ToDataSourceResult(request, ModelState));
        }
    }
}
