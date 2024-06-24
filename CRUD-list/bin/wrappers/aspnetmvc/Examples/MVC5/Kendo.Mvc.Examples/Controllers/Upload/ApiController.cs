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
        public ActionResult Api()
        {
            return View();
        }

        public ActionResult Api_Save(IEnumerable<HttpPostedFileBase> files)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                }
            }
            
            return Content("");
        }

        public ActionResult Api_Remove(string[] fileNames)
        {

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                  
                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }
            
            return Content("");
        }
    }
}