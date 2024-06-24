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
    public partial class ListViewController : Controller
    {
        [Demo]
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        public ActionResult Remote_Data_Binding_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }
    }
}