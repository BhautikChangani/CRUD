using Kendo.Mvc.UI;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class StepperController : Controller
    {
        [Demo]
        public ActionResult Orientation(string orientation)
        {
            StepperOrientationType value = StepperOrientationType.Horizontal;

            if (orientation == "vertical")
            {
                value = StepperOrientationType.Vertical;
            }
            return View(value);
        }
    }
}