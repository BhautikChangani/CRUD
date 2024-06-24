using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public ActionResult Operation_Modes(string mode)
        {
            var model = new StepperViewModel();

            model.Linear = (mode == "false") ? false : true;

            return View(model);
        }
    }
}