using Kendo.Mvc.Examples.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using IOFile = System.IO.File;

namespace Kendo.Mvc.Examples.Controllers
{ 
    public partial class AccessibilityController : Controller
    {
        public ActionResult Index()
        {
            var assetsCDN = ConfigurationManager.AppSettings["AssetsCDN"];
            ViewBag.AssetsCDN = assetsCDN;
            ViewBag.Examples = JsonConvert.DeserializeObject<AccessibilityExample[]>(IOFile.ReadAllText(Server.MapPath("~/Content/accessibility-assets/accessibility-nav.json")));
            return View();
        }

        public ActionResult Example(string widget)
        {
            return View(
                string.Format("~/Views/Accessibility/{0}.cshtml", widget)
            );
        }

        public ActionResult Asset(string path)
        {
            return Redirect("../content/accessibility-assets/" + path);
        }
    }
}