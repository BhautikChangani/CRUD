using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Step_Line_ChartsController : Controller
    {
        public ActionResult Date_Axis()
        {
            return View(ChartDataRepository.DatePoints());
        }
    }
}