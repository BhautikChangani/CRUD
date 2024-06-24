using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{

    public partial class Bar_ChartsController : Controller
    {
        [Demo]
        public ActionResult Plotbands()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Plotbands_SpainElectricityProduction()
        {
            return Json(ChartDataRepository.SpainElectricityProduction());
        }
    }
}
