using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class CardsController : Controller
    {
        [Demo]
        public ActionResult Layout()
        {
            return View();
        }
    }
}