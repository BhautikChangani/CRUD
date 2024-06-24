using System;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        [Demo]
        public ActionResult Custom_Editors()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Editors_Proxy(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}
