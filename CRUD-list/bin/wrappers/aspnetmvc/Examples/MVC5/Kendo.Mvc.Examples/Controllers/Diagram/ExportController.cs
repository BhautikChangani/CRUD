using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Export()
        {
            ViewData["baseUrl"] = Request.Url.GetLeftPart(UriPartial.Authority);
            return View();
        }

        public ActionResult Export_Read()
        {
            return Json(DiagramDataRepository.OrgChart(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}
