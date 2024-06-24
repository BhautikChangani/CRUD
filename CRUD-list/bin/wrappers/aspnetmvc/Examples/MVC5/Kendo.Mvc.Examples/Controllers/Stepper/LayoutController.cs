using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public ActionResult Layout(string layout)
        {
            var model = new StepperViewModel();

            if (layout == "label")
            {
                model.Label = true;
                model.Indicator = false;
            }
            else if (layout == "indicator")
            {
                model.Label = false;
                model.Indicator = true;
            }
            else
            {
                model.Label = true;
                model.Indicator = true;
            }

            return View(model);
        }
    }
}