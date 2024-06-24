using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _OrgChart()
        {
            return Json(DiagramDataRepository.OrgChart(), JsonRequestBehavior.AllowGet);
        }
    }
}
