using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SpreadsheetController : Controller
    {
        private SpreadsheetProductService productService;

        public SpreadsheetController()
        {
            productService = new SpreadsheetProductService(new DemoDBContext());
        }

        protected override void Dispose(bool disposing)
        {
            productService.Dispose();

            base.Dispose(disposing);
        }

        [Demo]
        public ActionResult DataSource()
        {
            return View();
        }

        public ActionResult Data_Source_Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Data_Source_Products_Submit(SpreadsheetSubmitViewModel model)
        {
            var result = new SpreadsheetSubmitViewModel()
            {
                Created = new List<SpreadsheetProductViewModel>(),
                Updated = new List<SpreadsheetProductViewModel>(),
                Destroyed = new List<SpreadsheetProductViewModel>()
            };

            if ((model.Created != null || model.Updated != null || model.Destroyed != null) && ModelState.IsValid)
            {
                if (model.Created != null)
                {
                    foreach (var created in model.Created)
                    {
                        productService.Create(created);
                        result.Created.Add(created);
                    }
                }

                if (model.Updated != null)
                {
                    foreach (var updated in model.Updated)
                    {
                        productService.Update(updated);
                        result.Updated.Add(updated);
                    }
                }

                if (model.Destroyed != null)
                {
                    foreach (var destroyed in model.Destroyed)
                    {
                        productService.Destroy(destroyed);
                        result.Destroyed.Add(destroyed);
                    }
                }

                return Json(result);
            }
            else
            {
                return new HttpStatusCodeResult(400, "The models contain invalid property values.");
            }
        }

        [HttpPost]
        public ActionResult Data_Source_Proxy(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}