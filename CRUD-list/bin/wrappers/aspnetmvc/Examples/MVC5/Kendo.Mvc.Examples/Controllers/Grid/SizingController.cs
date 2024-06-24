using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController
    {
        [Demo]
        public ActionResult Sizing()
        {
            return View();
        }
        public ActionResult BoeingStockDataRead([DataSourceRequest] DataSourceRequest request)
        {
            var db = new DemoDBContext();

            var result = from s in db.Stocks
                         where s.Symbol == "BA"
                         select new StockDataPoint
                         {
                             Date = s.Date,
                             Open = s.Open,
                             High = s.High,
                             Low = s.Low,
                             Close = s.Close,
                             Volume = s.Volume
                         };

            return Json(result.ToDataSourceResult(request));
        }
    }
}
