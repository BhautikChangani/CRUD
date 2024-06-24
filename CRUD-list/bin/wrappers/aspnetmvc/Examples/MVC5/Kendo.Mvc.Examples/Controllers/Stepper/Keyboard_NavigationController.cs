using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation(bool? selectOnFocus)
        {
            var model = new StepperViewModel();

            model.SelectOnFocus = (selectOnFocus == null) ? false : true;

            return View(model);
        }
    }
}