namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.Examples.Models.Scheduler;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public partial class SchedulerController : Controller
    {
        [Demo]
        public ActionResult Move_Resize()
        {
            return View();
        }

        public virtual JsonResult Move_Resize_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Move_Resize_Destroy([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Move_Resize_Create([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Move_Resize_Update([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }
    }
}
