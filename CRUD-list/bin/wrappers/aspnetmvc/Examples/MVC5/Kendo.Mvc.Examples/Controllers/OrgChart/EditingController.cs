using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class OrgChartController : Controller
    {
        [Demo]
        public ActionResult Editing()
        {
            return View();
        }
        public JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(new
            {
                Data = OrgChartData
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Create(OrgChartEmployeeViewModel model)
        {
            int lastID = OrgChartData.Select(m =>m.ID).Max();
            if (model.ID == 0)
            {
                model.ID = lastID + 1;
            }
            OrgChartData.Add(model);

            return Json(model);
        }
        public JsonResult Destroy(OrgChartEmployeeViewModel model)
        {
            var target = One(m => m.ID == model.ID);
            OrgChartData.Remove(target);

            return Json(target);
        }
        public JsonResult Update(OrgChartEmployeeViewModel model)
        {
            var target = One(m => m.ID == model.ID);

            target.Title = model.Title;
            target.Name = model.Name;
            target.ParentID = model.ParentID;
            target.Avatar = model.Avatar;

            return Json(target);
        }
        public static OrgChartEmployeeViewModel One(Func<OrgChartEmployeeViewModel, bool> predicate)
        {
            return OrgChartData.FirstOrDefault(predicate);
        }
        private static IList<OrgChartEmployeeViewModel> OrgChartData
        {
            get
            {
                IList<OrgChartEmployeeViewModel> source = System.Web.HttpContext.Current.Session["OrgChartEmployees"] as IList<OrgChartEmployeeViewModel>;

                if (source == null)
                {
                    System.Web.HttpContext.Current.Session["OrgChartEmployees"] = source = new List<OrgChartEmployeeViewModel>
                    {
                    new OrgChartEmployeeViewModel() { ID = 1, Name = "Gevin Bell", Title = "CEO", Expanded = true, Avatar = "../content/web/treelist/people/1.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 2, Name = "Clevey Thrustfield", Title = "COO", Expanded = true, ParentID = 1, Avatar = "../content/web/treelist/people/2.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 3, Name = "Carol Baker", Title = "CFO", Expanded = false, ParentID = 1, Avatar = "../content/web/treelist/people/3.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 4, Name = "Kendra Howell", Title = "CMO", Expanded = false, ParentID = 1, Avatar = "../content/web/treelist/people/4.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 5, Name = "Sean Rusell", Title = "Financial Manager", Expanded = true, ParentID = 3, Avatar = "../content/web/treelist/people/5.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 6, Name = "Steven North", Title = "Senior Manager", Expanded = false, ParentID = 3, Avatar = "../content/web/treelist/people/6.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 7, Name = "Michelle Hudson", Title = "Operations Manager", Expanded = true, ParentID = 2, Avatar = "../content/web/treelist/people/7.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 8, Name = "Andrew Berry", Title = "Team Lead", ParentID = 5, Avatar = "../content/web/treelist/people/8.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 9, Name = "Jake Miller", Title = "Junior Accountant", ParentID = 5, Avatar = "../content/web/treelist/people/9.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 10, Name = "Austin Piper", Title = "Accountant", ParentID = 5, Avatar = "../content/web/treelist/people/10.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 11, Name = "Dilyana Newman", Title = "Accountant", ParentID = 5, Avatar = "../content/web/treelist/people/11.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 12, Name = "Eva Andrews", Title = "Team Lead", ParentID = 6, Avatar = "../content/web/treelist/people/12.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 13, Name = "Kaya Nilsen", Title = "Financial Specialist", ParentID = 6, Avatar = "../content/web/treelist/people/13.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 14, Name = "Elena Austin", Title = "Team Lead", ParentID = 4, Avatar = "../content/web/treelist/people/14.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 15, Name = "Lora Samuels", Title = "Lawyer", ParentID = 4, Avatar = "../content/web/treelist/people/15.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 16, Name = "Lillian Carr", Title = "Operator", ParentID = 7, Avatar = "../content/web/treelist/people/17.jpg" },
                    new OrgChartEmployeeViewModel() { ID = 17, Name = "David Henderson", Title = "Team Lead", ParentID = 7, Avatar = "../content/web/treelist/people/16.jpg" },
                };
                }
                return source;
            }
        }
    }
}