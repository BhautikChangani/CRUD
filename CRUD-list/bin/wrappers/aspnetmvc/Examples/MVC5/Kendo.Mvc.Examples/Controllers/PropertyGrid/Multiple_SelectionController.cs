using Kendo.Mvc.Examples.Models.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PropertyGridController : Controller
    {
        [Demo]
        public ActionResult Multiple_Selection()
        {
            return View(new MultipleSelectionViewModel()
            {
                size = "medium",
                rounded = "medium",
                fillMode = "solid",
                themeColor = "base",
                icon = "star",
                enable = true,
                font = new FontViewModel()
                {
                    fontWeight = 400,
                    fontFamily = "Roboto"
                }
            });
        }
    }
}