using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DataSourceController : Controller
    {

        [Demo]
        public ActionResult Index()
        {
            return View();
        }
    }
}