using Kendo.Mvc.Examples.Models;
using System.Web.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MenuController : Controller
    {
        [Demo]
        public ActionResult ModelBinding()
        {
            var northwind = new DemoDBContext();
            return View(northwind.Categories);
        }
    }
}
