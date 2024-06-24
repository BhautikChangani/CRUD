using System.Collections.Generic;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListBoxController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            ViewBag.Attendees = new List<SelectListItem>
            {
                new SelectListItem(){ Value = "1", Text = "Steven White" },
                new SelectListItem(){ Value = "2", Text = "Nancy King" },
                new SelectListItem(){ Value = "3", Text = "Nancy Davolio" },
                new SelectListItem(){ Value = "4", Text = "Michael Leverling" },
                new SelectListItem(){ Value = "5", Text = "Andrew Callahan" },
                new SelectListItem(){ Value = "6", Text = "Michael Suyama" },
            };

            return View();
        }
    }
}
