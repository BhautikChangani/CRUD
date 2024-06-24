using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class HeatMapController : Controller
    {
        [Demo]
        public ActionResult Markers()
        {
            return View();
        }
        public ActionResult HeatMap_Markers_Data()
        {
            ICollection<HeatMapModel> data = GetData(10, 20);
            return Json(data);
        }
    }
}
