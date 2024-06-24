using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        //
        // GET: /Toggle_Pager/
        [Demo]
        public ActionResult Pager_Functionality()
        {
            return View();
        }

        public ActionResult Pager_Visibility_Editing_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pager_Visibility_Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            var results = new List<ProductViewModel>();

            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    productService.Create(product);
                    results.Add(product);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pager_Visibility_Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    productService.Update(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Pager_Visibility_Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            if (products.Any())
            {
                foreach (var product in products)
                {
                    productService.Destroy(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }
    }
}
