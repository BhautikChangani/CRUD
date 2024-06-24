using System;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Cell_Comments()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cell_Comments_Proxy(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}
