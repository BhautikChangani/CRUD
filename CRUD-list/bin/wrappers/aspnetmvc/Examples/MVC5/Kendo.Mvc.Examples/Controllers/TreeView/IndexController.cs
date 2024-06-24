using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class TreeViewController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read_Overview(string id)
        {
            IEnumerable<TreeViewItemViewModel> result;
            if (string.IsNullOrEmpty(id))
            {
                result = TreeViewRepository.GetProjectData().Select(o => o.Clone());                
            }
            else
            {
                result = TreeViewRepository.GetChildren(id);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}