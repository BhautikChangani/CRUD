using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DiagramController : Controller
    {
        [Demo]
        public ActionResult Pdf_Export()
        {
            return View();
        }

        public ActionResult Pdf_Export_Read()
        {
            return Json(DiagramDataRepository.OrgChart(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Pdf_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}