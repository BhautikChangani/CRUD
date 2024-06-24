using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TaskBoardController : Controller
    {
        [Demo]
        public ActionResult Right_To_Left_Support()
        {
            ViewBag.Cards = GetCards();

            return View();
        }
    }
}
