using Kendo.Mvc.Examples.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class UploadController : Controller
    {
        [Demo]
        public ActionResult Index(UploadOverviewModel model)
        {
            if (model.AllowedExtensions == null)
            {
                model = new UploadOverviewModel()
                {
                    AllowedExtensions = new string[] { "jpg", "pdf", "docx", "xlsx", "zip" },
                    IsLimited = false
                };
            };
             
            return View(model);
        }
    }
}