namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class ColorPickerController : Controller
    {
        [Demo]
        public ActionResult Palette()
        {
            return View();
        }
    }
}