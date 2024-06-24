using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PivotGridV2Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            var model = productService.Read();

            return View(model);
        }
    }
}
