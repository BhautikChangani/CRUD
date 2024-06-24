using System.Web.Mvc;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeListController : Controller
    {
        [Demo]
        public ActionResult Persist_State()
        {
            return View();
        }
    }
}