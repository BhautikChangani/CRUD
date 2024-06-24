using System.Web.Mvc;
using System.Web.Routing;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : Controller
    {
        [Demo]
        public ActionResult Checkboxes()
        {
            return View(new string[0]);
        }        
    }
}