using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult Filter_Row()
        {
            return View();
        }

        public ActionResult FilterRow_Positions()
        {
            var result = GetDirectory().Select(e => e.Position).Distinct().ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}