using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class RatingController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
    }
}