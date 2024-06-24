using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : Controller
    {
        [Demo]
        public ActionResult ForeignKeyColumnBinding()
        {            
            return View();
        }

        public ActionResult Categories()
        {
            var dataContext = new DemoDBContext();
            var categories = dataContext.Categories
                        .Select(c => new CategoryViewModel
                        {
                            CategoryID = c.CategoryID,
                            CategoryName = c.CategoryName
                        })
                        .OrderBy(e => e.CategoryName);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}
