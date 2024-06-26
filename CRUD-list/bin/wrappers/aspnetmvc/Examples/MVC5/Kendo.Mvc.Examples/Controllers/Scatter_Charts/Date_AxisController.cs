using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Scatter_ChartsController : Controller
    {
        [Demo]
        public ActionResult Date_Axis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _StockData()
        {
            return Json(ChartDataRepository.StockData());
        }
    }
}