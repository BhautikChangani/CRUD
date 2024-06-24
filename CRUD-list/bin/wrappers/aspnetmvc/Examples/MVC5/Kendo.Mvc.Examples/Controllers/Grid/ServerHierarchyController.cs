using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult ServerHierarchy()
        {
            return View(new DemoDBContext().Employees);
        }
    }
}