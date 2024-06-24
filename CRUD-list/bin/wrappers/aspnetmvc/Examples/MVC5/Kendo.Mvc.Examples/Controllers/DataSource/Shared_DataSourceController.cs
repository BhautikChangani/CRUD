using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DataSourceController : Controller
    {
        private ProductService productService;

        public DataSourceController()
        {
            productService = new ProductService(new DemoDBContext());
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();
            base.Dispose(disposing);
        }

        [Demo]
        public ActionResult Shared_Datasource()
        {
            return View();
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}