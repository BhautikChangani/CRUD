using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using Kendo.Mvc.Examples.Models.Gantt;

namespace Kendo.Mvc.Examples.Controllers
{﻿
    public partial class GanttController : Controller
    {
        private GanttTaskService taskService;
        private GanttDependencyService dependencyService;
        private GanttAssignmentService assignmentService;
        private GanttResourceService resourceService;

        public GanttController()
        {
            taskService = new GanttTaskService();
            dependencyService = new GanttDependencyService();
            assignmentService = new GanttAssignmentService();
            resourceService = new GanttResourceService();
        }

        protected override void Dispose(bool disposing)
        {
            taskService.Dispose();
            dependencyService.Dispose();

            base.Dispose(disposing);
        }

        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public virtual JsonResult Read_Tasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Delete(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Insert(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update_Task([DataSourceRequest] DataSourceRequest request, TaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(task, ModelState);
            }

            return Json(new[] { task }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Read_Dependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Read_Resources([DataSourceRequest] DataSourceRequest request)
        {
            return Json(resourceService.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Read_Assignments([DataSourceRequest] DataSourceRequest request)
        {
            return Json(assignmentService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Destroy_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Delete(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Create_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Insert(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Update_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Update(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }
    }
}