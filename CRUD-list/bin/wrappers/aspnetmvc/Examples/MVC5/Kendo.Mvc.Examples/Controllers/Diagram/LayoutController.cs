using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult _DiagramTree()
        {
            return Json(DiagramDataRepository.DiagramNodes(), JsonRequestBehavior.AllowGet);
        }
    }
}
