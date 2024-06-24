namespace Kendo.Mvc.Examples.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class AutoCompleteController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Overview_GetCountries()
        {
            List<SelectListItem> countries = GetData();

            return Json(countries, JsonRequestBehavior.AllowGet);
        }
        private static List<SelectListItem> GetData()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem{ Value = "1", Text = "Lisboa"},
                new SelectListItem{ Value = "2", Text = "Moscow"},
                new SelectListItem{ Value = "3", Text = "Napoli"},
                new SelectListItem{ Value = "4", Text = "Tokyo"},
                new SelectListItem{ Value = "5", Text = "Oslo"},
                new SelectListItem{ Value = "6", Text = "Pаris"},
                new SelectListItem{ Value = "7", Text = "Porto"},
                new SelectListItem{ Value = "8", Text = "Rome"},
                new SelectListItem{ Value = "9", Text = "Berlin"},
                new SelectListItem{ Value = "10",Text = "Nice"},
                new SelectListItem{ Value = "11",Text = "New York"},
                new SelectListItem{ Value = "12",Text = "Sao Paulo"},
                new SelectListItem{ Value = "13",Text = "Rio De Janeiro"},
                new SelectListItem{ Value = "14",Text = "Venice"},
                new SelectListItem{ Value = "15",Text = "Los Angeles"},
                new SelectListItem{ Value = "16",Text = "Madrid"},
                new SelectListItem{ Value = "17",Text = "Barcelona"},
                new SelectListItem{ Value = "18",Text = "Prague"},
                new SelectListItem{ Value = "19",Text = "Mexico City"},
                new SelectListItem{ Value = "20",Text = "Buenos Aires"}
            };
        }
    }
}