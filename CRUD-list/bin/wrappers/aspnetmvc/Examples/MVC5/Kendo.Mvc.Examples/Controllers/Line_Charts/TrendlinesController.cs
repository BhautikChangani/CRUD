using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Line_ChartsController : Controller
    {
        [Demo]
        public ActionResult Trendlines()
        {
            return View(ChartDataRepository.SalesPerQuarter());
        }
    }
}