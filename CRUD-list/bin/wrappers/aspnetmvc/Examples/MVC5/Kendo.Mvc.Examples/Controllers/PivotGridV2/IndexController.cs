using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PivotGridV2Controller : Controller
    {
        private ProductService productService;

        public PivotGridV2Controller()
        {
            productService = new ProductService(new DemoDBContext());
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();

            base.Dispose(disposing);
        }

        [Demo]
        public ActionResult Index()
        {
            return View();
        }
    }
}
