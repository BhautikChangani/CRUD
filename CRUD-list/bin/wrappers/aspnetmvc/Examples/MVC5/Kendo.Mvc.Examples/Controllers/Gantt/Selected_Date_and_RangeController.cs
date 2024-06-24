using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Web.Mvc;
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GanttController : Controller
    {
        [Demo]
        public ActionResult Selected_Date_and_Range()
        {
            return View();
        }

        public virtual JsonResult Selected_Date_Range_Read_Tasks([DataSourceRequest] DataSourceRequest request)
        {
            return Json(taskService.GetAll().ToDataSourceResult(request));
        }

        public virtual JsonResult Selected_Date_Range_Read_Dependencies([DataSourceRequest] DataSourceRequest request)
        {
            return Json(dependencyService.GetAll().ToDataSourceResult(request));
        }
    }
}
