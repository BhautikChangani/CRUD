using System;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Line_ChartsController : Controller
    {
        [Demo]
        public ActionResult Local_Data_Binding()
        {
            return View(ChartDataRepository.InternetUsers());
        }
    }
}