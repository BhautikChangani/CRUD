namespace Kendo.Mvc.Examples.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public partial class ComboBoxController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Overview_GetHobbies()
        {
            List<SelectListItem> hobbies = GetData();

            return Json(hobbies, JsonRequestBehavior.AllowGet);
        }

        private static List<SelectListItem> GetData()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = "Football"},
                new SelectListItem { Value = "2", Text = "Golf" },
                new SelectListItem { Value = "3", Text = "Baseball" },
                new SelectListItem { Value = "4", Text = "Table Tennis" },
                new SelectListItem { Value = "5", Text = "Volleyball" },
                new SelectListItem { Value = "6", Text = "Basketball" },
                new SelectListItem { Value = "7", Text = "Boxing" },
                new SelectListItem { Value = "8", Text = "Badminton" },
                new SelectListItem { Value = "9", Text = "Cycling" },
                new SelectListItem { Value = "10", Text = "Gymnastics" },
                new SelectListItem { Value =  "11", Text = "Swimming" },
                new SelectListItem { Value =  "12", Text = "Wrestling" },
                new SelectListItem { Value =  "13", Text = "Snooker" },
                new SelectListItem { Value =  "14", Text = "Skiing" },
                new SelectListItem { Value =  "15", Text = "Handball" }
            };
        }
    }
}