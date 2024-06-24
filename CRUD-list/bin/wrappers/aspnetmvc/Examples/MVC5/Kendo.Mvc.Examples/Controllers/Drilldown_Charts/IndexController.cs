using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers.Drilldown_Charts
{
    public partial class Drilldown_ChartsController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Get_Companies()
        {
            return Json(ChartDataRepository.Companies(), JsonRequestBehavior.AllowGet);
        }
    }
}