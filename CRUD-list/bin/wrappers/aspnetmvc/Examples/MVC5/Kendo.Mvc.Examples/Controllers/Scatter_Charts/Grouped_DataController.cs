using Kendo.Mvc.Examples.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Scatter_ChartsController : Controller
    {
        [Demo]
        public ActionResult Grouped_Data()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Grouped_StockData()
        {
            return Json(ChartDataRepository.StockData());
        }
    }
}