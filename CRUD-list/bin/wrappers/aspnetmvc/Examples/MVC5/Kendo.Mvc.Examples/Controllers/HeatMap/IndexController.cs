using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class HeatMapController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contributions()
        {
            var HeatMapData = new List<object> {
                new {Week = 1, Day = "Mon", Value = 8},  new {Week = 1, Day = "Tue", Value = 4},  new {Week = 1, Day = "Wed", Value = 7},  new {Week = 1, Day = "Thu", Value = 14}, new {Week = 1, Day = "Fri", Value = 10}, new {Week = 1, Day = "Sat", Value = 0}, new {Week = 1, Day = "Sun", Value = 0},
                new {Week = 2, Day = "Mon", Value = 6},  new {Week = 2, Day = "Tue", Value = 6},  new {Week = 2, Day = "Wed", Value = 9},  new {Week = 2, Day = "Thu", Value = 12}, new {Week = 2, Day = "Fri", Value = 12}, new {Week = 2, Day = "Sat", Value = 3}, new {Week = 2, Day = "Sun", Value = 0},
                new {Week = 3, Day = "Mon", Value = 5},  new {Week = 3, Day = "Tue", Value = 5},  new {Week = 3, Day = "Wed", Value = 8},  new {Week = 3, Day = "Thu", Value = 11}, new {Week = 3, Day = "Fri", Value = 0}, new {Week = 3, Day = "Sat", Value = 1}, new {Week = 3, Day = "Sun", Value = 0},
                new {Week = 4, Day = "Mon", Value = 0},  new {Week = 4, Day = "Tue", Value = 0},  new {Week = 4, Day = "Wed", Value = 0},  new {Week = 4, Day = "Thu", Value = 0}, new {Week = 4, Day = "Fri", Value = 0}, new {Week = 4, Day = "Sat", Value = 0}, new {Week = 4, Day = "Sun", Value = 0},
                new {Week = 5, Day = "Mon", Value = 9},  new {Week = 5, Day = "Tue", Value = 0},  new {Week = 5, Day = "Wed", Value = 0},  new {Week = 5, Day = "Thu", Value = 0}, new {Week = 5, Day = "Fri", Value = 0}, new {Week = 5, Day = "Sat", Value = 0}, new {Week = 5, Day = "Sun", Value = 0},
                new {Week = 6, Day = "Mon", Value = 6},  new {Week = 6, Day = "Tue", Value = 4},  new {Week = 6, Day = "Wed", Value = 7},  new {Week = 6, Day = "Thu", Value = 14}, new {Week = 6, Day = "Fri", Value = 10}, new {Week = 6, Day = "Sat", Value = 2}, new {Week = 6, Day = "Sun", Value = 0},
                new {Week = 7, Day = "Mon", Value = 4},  new {Week = 7, Day = "Tue", Value = 6},  new {Week = 7, Day = "Wed", Value = 9},  new {Week = 7, Day = "Thu", Value = 2}, new {Week = 7, Day = "Fri", Value = 4}, new {Week = 7, Day = "Sat", Value = 0}, new {Week = 7, Day = "Sun", Value = 0},
                new {Week = 8, Day = "Mon", Value = 11},  new {Week = 8, Day = "Tue", Value = 4},  new {Week = 8, Day = "Wed", Value = 7},  new {Week = 8, Day = "Thu", Value = 14}, new {Week = 8, Day = "Fri", Value = 10}, new {Week = 8, Day = "Sat", Value = 0}, new {Week = 8, Day = "Sun", Value = 0},
                new {Week = 9, Day = "Mon", Value = 5},  new {Week = 9, Day = "Tue", Value = 4},  new {Week = 9, Day = "Wed", Value = 7},  new {Week = 9, Day = "Thu", Value = 4}, new {Week = 9, Day = "Fri", Value = 1}, new {Week = 9, Day = "Sat", Value = 0}, new {Week = 9, Day = "Sun", Value = 0},
                new {Week = 10, Day = "Mon", Value = 3}, new {Week = 10, Day = "Tue", Value = 6}, new {Week = 10, Day = "Wed", Value = 9}, new {Week = 10, Day = "Thu", Value = 12}, new {Week = 10, Day = "Fri", Value = 12}, new {Week = 10, Day = "Sat", Value = 4}, new {Week = 10, Day = "Sun", Value = 0},
                new {Week = 11, Day = "Mon", Value = 1}, new {Week = 11, Day = "Tue", Value = 4}, new {Week = 11, Day = "Wed", Value = 7}, new {Week = 11, Day = "Thu", Value = 10}, new {Week = 11, Day = "Fri", Value = 10}, new {Week = 11, Day = "Sat", Value = 0}, new {Week = 11, Day = "Sun", Value = 0},
                new {Week = 12, Day = "Mon", Value = 0}, new {Week = 12, Day = "Tue", Value = 4}, new {Week = 12, Day = "Wed", Value = 7}, new {Week = 12, Day = "Thu", Value = 8}, new {Week = 12, Day = "Fri", Value = 10}, new {Week = 12, Day = "Sat", Value = 0}, new {Week = 12, Day = "Sun", Value = 0}
            };

            return Json(HeatMapData);
        }
    }
}