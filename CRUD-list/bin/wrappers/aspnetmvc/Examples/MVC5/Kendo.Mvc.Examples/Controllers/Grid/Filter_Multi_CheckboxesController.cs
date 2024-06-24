using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Reflection;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Filter_Multi_Checkboxes()
        {
            return View();
        }

        public ActionResult Unique(string field)
        {
            var result = GetEmployees().Distinct(new EmployeeComparer(field));

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Filter_Multi_HierarchyBinding_Employees([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        public ActionResult Filter_Multi_Editing_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Filter_Multi_Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
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
        public ActionResult Filter_Multi_Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
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
        public ActionResult Filter_Multi_Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
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

    public class EmployeeComparer : IEqualityComparer<EmployeeViewModel>
    {
        private string field;

        private PropertyInfo prop;

        public EmployeeComparer(string field)
        {
            this.field = field;
            prop = typeof(EmployeeViewModel).GetProperty(field);
        }

        public bool Equals(EmployeeViewModel x, EmployeeViewModel y)
        {
            var valueX = prop.GetValue(x, null);
            var valueY = prop.GetValue(y, null);
            if (valueX == null)
            {
                return valueY == null;
            }
            return valueX.Equals(valueY);
        }

        public int GetHashCode(EmployeeViewModel obj)
        {
            var value = prop.GetValue(obj, null);
            if (value == null)
            {
                return 0;
            }
            return value.GetHashCode();
        }
    }    
}
