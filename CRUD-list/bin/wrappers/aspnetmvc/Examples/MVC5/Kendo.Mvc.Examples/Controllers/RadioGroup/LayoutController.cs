using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class RadioGroupController : Controller
    {
        [Demo]
        public ActionResult Layout(string layout, string labelPosition)
        {
            RadioGroupLayout layoutValue = RadioGroupLayout.Vertical;
            if (layout == "Horizontal")
            {
                layoutValue = RadioGroupLayout.Horizontal;
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
