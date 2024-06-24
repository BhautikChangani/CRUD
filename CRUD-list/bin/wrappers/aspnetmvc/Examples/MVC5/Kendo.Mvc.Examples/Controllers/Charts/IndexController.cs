using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models.Chart;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ChartsController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesByProductCategory()
        {
            return Json(ChartOverviewDataRepository.ProductCategoriesData());
        }

        [HttpPost]
        public ActionResult FunnelSales()
        {
            return Json(ChartOverviewDataRepository.FunnelSalesData());
        }

        [HttpPost]
        public ActionResult SalesByRegion()
        {
            return Json(ChartOverviewDataRepository.RegionSalesData());
        }
        [HttpPost]
        public ActionResult SalesPerformers()
        {
            return Json(ChartOverviewDataRepository.SalesPerformers());
        }

        [HttpPost]
        public ActionResult BoeingStockDataRead()
        {
            var db = new DemoDBContext();

            return Json(
                from s in db.Stocks
                where s.Symbol == "BA"
                select new StockDataPoint
                {
                    Date = s.Date,
                    Open = s.Open,
                    High = s.High,
                    Low = s.Low,
                    Close = s.Close,
                    Volume = s.Volume
                }
            );
        }
    }
}
