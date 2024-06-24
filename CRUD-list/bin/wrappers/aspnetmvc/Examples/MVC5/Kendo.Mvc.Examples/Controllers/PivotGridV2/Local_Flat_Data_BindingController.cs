using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PivotGridV2Controller
    {
        [Demo]
        public ActionResult Local_Flat_Data_Binding()
        {
            var model = productService.Read();

            return View(model);
        }
    }
}
