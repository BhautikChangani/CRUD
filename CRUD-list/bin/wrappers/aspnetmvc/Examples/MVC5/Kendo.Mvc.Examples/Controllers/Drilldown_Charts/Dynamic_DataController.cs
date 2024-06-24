using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers.Drilldown_Charts
{
    public partial class Drilldown_ChartsController : Controller
    {
        [Demo]
        public ActionResult Dynamic_Data()
        {
            ViewData["VehiclesByModel"] = ChartDataRepository.VehicleModels();
            ViewData["VehiclesByQuarter"] = ChartDataRepository.VehicleQuarters();

            return View();
        }
        public ActionResult Get_VehicleMakes()
        {
            return Json(ChartDataRepository.VehicleMakes(), JsonRequestBehavior.AllowGet);
        }
    }
}