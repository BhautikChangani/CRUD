using Kendo.Mvc.Examples.Models.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PropertyGridController : Controller
    {
        [Demo]
        public ActionResult Api()
        {
            return View(new PropertyViewModel()
            {
                size = ComponentSize.Medium,
                rounded = Rounded.Medium,
                fillMode = ButtonFillMode.Solid,
                themeColor = ThemeColor.Base,
                icon = "star",
                font = new FontViewModel()
                {
                    fontWeight = 400,
                    fontFamily = "Roboto"
                },
                alignment = new AlignmentViewModel()
                {
                    margin = 20,
                    padding = 50
                }
            });
        }
    }
}