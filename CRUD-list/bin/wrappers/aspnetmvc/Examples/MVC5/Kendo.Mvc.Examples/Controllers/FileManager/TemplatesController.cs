using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FileManagerController : Controller
    {
        [Demo]
        public ActionResult Templates()
        {
            return View();
        }
    }
}
