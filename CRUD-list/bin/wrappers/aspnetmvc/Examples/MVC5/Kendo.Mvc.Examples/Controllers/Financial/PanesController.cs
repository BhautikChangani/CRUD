using Kendo.Mvc.Examples.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FinancialController : Controller
    {
        [Demo]
        public ActionResult Panes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Panes_BoeingStockData()
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