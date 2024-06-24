using Kendo.Mvc.Examples.Models.GridLayout;
using System;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridLayoutController : Controller
    {
        [Demo]
        public ActionResult Adaptive()
        {
            var viewModel = new GridLayoutData()
            {
                Articles = GetArticles(DateTime.Today)
            };

            return View(viewModel);
        }
    }
}