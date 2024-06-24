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
        public ActionResult Pan_And_Zoom()
        {
            return View();
        }

        public ActionResult HeatMap_Data()
        {
            ICollection<HeatMapModel> data = GetData(25, 25);
            return Json(data);
        }
    }
}
