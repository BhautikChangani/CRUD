using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models.Gantt;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Task_Template()
        {
            return View();
        }

        public virtual JsonResult Templates_Read_Tasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(Templates_GetTasks().ToDataSourceResult(request));
        }

        public virtual JsonResult Templates_Read_Dependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Templates_Destroy_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Delete(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Templates_Create_Dependency([DataSourceRequest] DataSourceRequest request, DependencyViewModel dependency)
        {
            if (ModelState.IsValid)
            {
                dependencyService.Insert(dependency, ModelState);
            }

            return Json(new[] { dependency }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Templates_Read_Resources([DataSourceRequest] DataSourceRequest request)
        {
            return Json(resourceService.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult Templates_Read_Assignments([DataSourceRequest] DataSourceRequest request)
        {
            return Json(assignmentService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Templates_Destroy_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Delete(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Templates_Create_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Insert(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public virtual JsonResult Templates_Update_Assignment([DataSourceRequest] DataSourceRequest request, ResourceAssignmentViewModel assignment)
        {
            if (ModelState.IsValid)
            {
                assignmentService.Update(assignment);
            }

            return Json(new[] { assignment }.ToDataSourceResult(request, ModelState));
        }

        public List<TaskViewModel> Templates_GetTasks()
        {
            List<TaskViewModel> ganttTasks = new List<TaskViewModel>
            {
                new TaskViewModel
                {
                    TaskID = 7,
                    Title = "Software validation, research and implementation",
                    ParentID = null,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 1, 3, 0, 0),
                    End = new DateTime(2020, 6, 18, 3, 0, 0),
                    PercentComplete = 0.43M,
                    Summary = true,
                    Expanded = true,
                    TeamLead = "Darrel Solis"
                },
                new TaskViewModel
                {
                    TaskID = 18,
                    Title = "Project Kickoff",
                    ParentID = 7,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 1, 3, 0, 0),
                    End = new DateTime(2020, 6, 1, 3, 0, 0),
                    PercentComplete = 0.23M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Mallory Gilliam"
                },
                new TaskViewModel
                {
                    TaskID = 13,
                    Title = "Implementation",
                    ParentID = 7,
                    OrderId = 1,
                    Start = new DateTime(2020, 6, 3, 3, 0, 0),
                    End = new DateTime(2020, 6, 17, 3, 0, 0),
                    PercentComplete = 0.77M,
                    Summary = true,
                    Expanded = true,
                    TeamLead = "Mia Caldwell"
                },
                new TaskViewModel
                {
                    TaskID = 24,
                    Title = "Prototype",
                    ParentID = 13,
                    OrderId = 0,
                    Start = new DateTime(2020, 6, 3, 3, 0, 0),
                    End = new DateTime(2020, 6, 5, 3, 0, 0),
                    PercentComplete = 0.77M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Drew Mckay"
                },
                new TaskViewModel
                {
                    TaskID = 26,
                    Title = "Architecture",
                    ParentID = 13,
                    OrderId = 1,
                    Start = new DateTime(2020, 6, 5, 3, 0, 0),
                    End = new DateTime(2020, 6, 7, 3, 0, 0),
                    PercentComplete = 0.82M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Zelda Medina"
                },
                new TaskViewModel
                {
                    TaskID = 27,
                    Title = "Data Layer",
                    ParentID = 13,
                    OrderId = 2,
                    Start = new DateTime(2020, 6, 7, 3, 0, 0),
                    End = new DateTime(2020, 6, 9, 3, 0, 0),
                    PercentComplete = 1.00M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Olga Strong"
                },
                new TaskViewModel
                {
                    TaskID = 28,
                    Title = "Unit Tests",
                    ParentID = 13,
                    OrderId = 4,
                    Start = new DateTime(2020, 6, 14, 3, 0, 0),
                    End = new DateTime(2020, 6, 17, 3, 0, 0),
                    PercentComplete = 0.68M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Christian Palmer"
                },
                new TaskViewModel
                {
                    TaskID = 29,
                    Title = "UI and Interaction",
                    ParentID = 13,
                    OrderId = 5,
                    Start = new DateTime(2020, 6, 7, 3, 0, 0),
                    End = new DateTime(2020, 6, 11, 3, 0, 0),
                    PercentComplete = 0.60M,
                    Summary = false,
                    Expanded = true,
                    TeamLead = "Moses Duncan"
                },
            };

            return ganttTasks;
        }
    }
}
