using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            PopulateCategories();
            PopulateCountries();
            return View();
        }

        public ActionResult DetailProducts_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(detailProductService.GetDetailProducts().ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    detailProductService.Update(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            var results = new List<DetailProductViewModel>();

            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    detailProductService.Create(product);
                    results.Add(product);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            if (products.Any())
            {
                foreach (var product in products)
                {
                    detailProductService.Destroy(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        private void PopulateCountries()
        {
            var dataContext = new DemoDBContext();
            var countries = dataContext.Countries
                        .Select(c => new CountryViewModel
                        {
                            CountryID = c.CountryID,
                            CountryNameShort = c.CountryNameShort,
                            CountryNameLong = c.CountryNameLong
                        })
                        .OrderBy(e => e.CountryNameLong);

            ViewData["countries"] = countries;
            ViewData["defaultCountry"] = countries.First();
        }
    }
}