using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Gantt;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Resources()
        {
            return View();
        }

        public virtual JsonResult Resources_Read_Tasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Resources_Destroy_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Create_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Update_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Read_Dependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Resources_Destroy_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Create_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Read_Resources([DataSourceRequest] DataSourceRequest request)
        {
            return Json(resourceService.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Resources_Read_Assignments([DataSourceRequest] DataSourceRequest request)
        {
            return Json(assignmentService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Resources_Destroy_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Delete(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Create_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Insert(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Resources_Update_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Update(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }
    }
}
