using Kendo.Mvc.Examples.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FinancialController : Controller
    {
        [Demo]
        public ActionResult Pdf_Export()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }

        [HttpPost]
        public ActionResult Export_BoeingStockData()
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