using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.TreeList;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            if (requestContext.HttpContext.Request.RequestType == "GET" && string.IsNullOrEmpty(requestContext.HttpContext.Request["culture"]))
            {
                requestContext.HttpContext.Session["selectedCulture"] = null;
            }

            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request["culture"]))
            {
                requestContext.HttpContext.Session["selectedCulture"] = requestContext.HttpContext.Request["culture"];

                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(requestContext.HttpContext.Request["culture"]);
            }
            else if (requestContext.HttpContext.Session["selectedCulture"] != null)
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo((string)requestContext.HttpContext.Session["selectedCulture"]);
            }

            base.Initialize(requestContext);
        }

        [Demo]
        public ActionResult Localization()
        {
            return View();
        }

        public JsonResult All([DataSourceRequest] DataSourceRequest request)
        {
            var result = GetDirectory().ToTreeDataSourceResult(request,
                e => e.EmployeeId,
                e => e.ReportsTo,
                e => e
            );

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Destroy([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeDirectory.Delete(employee, ModelState);
            }

            return Json(new[] { employee }.ToTreeDataSourceResult(request, ModelState));
        }

        public JsonResult Create([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeDirectory.Insert(employee, ModelState);
            }

            return Json(new[] { employee }.ToTreeDataSourceResult(request, ModelState));
        }

        public JsonResult Update([DataSourceRequest] DataSourceRequest request, EmployeeDirectoryModel employee)
        {
            if (ModelState.IsValid)
            {
                employeeDirectory.Update(employee, ModelState);
            }

            return Json(new[] { employee }.ToTreeDataSourceResult(request, ModelState));
        }

    }
}