namespace Kendo.Mvc.Examples.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;

    public partial class AutoCompleteController : Controller
    {
        [Demo]
        public ActionResult Prefix_Suffix()
        {
            return View();
        }

        public ActionResult GetCountries()
        {
            List<SelectListItem> countries = GetData();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }
    }
}