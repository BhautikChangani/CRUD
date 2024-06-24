using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CheckBoxGroupController : Controller
    {
        [Demo]
        public ActionResult Layout(string layout, string labelPosition)
        {
            CheckBoxGroupLayout layoutValue = CheckBoxGroupLayout.Vertical;
            if (layout == "Horizontal")
            {
                layoutValue = CheckBoxGroupLayout.Horizontal;
            }

            if (labelPosition == "before" || string.IsNullOrEmpty(labelPosition))
            {
                ViewBag.LabelPosition = "before";
            }
            else
            {
                ViewBag.LabelPosition = "after";
            }

            return View(layoutValue);
        }
    }
}
