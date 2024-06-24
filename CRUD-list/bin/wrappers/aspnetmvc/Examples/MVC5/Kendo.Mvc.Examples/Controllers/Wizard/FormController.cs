using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WizardController : Controller
    {
        [Demo]
        public ActionResult Form()
        {
            return View();
        }
    }
}
