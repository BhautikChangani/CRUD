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
        public ActionResult Responsive_Columns()
        {
            return View();
        }

        public ActionResult Responsive_Columns_Customers_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetCustomers().ToList().ToDataSourceResult(request));
        }
    }
}