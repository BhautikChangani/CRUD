using Kendo.Mvc.Examples.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Radar_ChartsController : Controller
    {
        [Demo]
        public ActionResult Smooth_Radar_Line()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Smooth_BudgetReport()
        {
            return Json(ChartDataRepository.BudgetReport());
        }
    }
}