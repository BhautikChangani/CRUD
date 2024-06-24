using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Template
{
    public partial class TemplateController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

    }
}
