using Kendo.Mvc.Examples.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Line_ChartsController : Controller
    {
        [Demo]
        public ActionResult Grouped_Data()
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