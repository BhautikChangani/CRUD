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
        public ActionResult Templates()
        {
            return View(new TemplateItemsViewModel()
            {
                text = "Lorem ipsum...",
                color = "red",
                icon = "star",
                font = new FontViewModel()
                {
                    fontWeight = 400,
                    fontFamily = "Roboto"
                }
            });
        }
    }
}