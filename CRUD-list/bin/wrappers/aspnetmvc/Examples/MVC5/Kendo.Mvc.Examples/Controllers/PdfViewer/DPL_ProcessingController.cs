using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Telerik.Web.PDF;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PdfViewerController : Controller
    {
        [Demo]
        public ActionResult Dpl_Processing()
        {
            return View();
        }

        public ActionResult GetInitialPdf(int? pageNumber)
        {
            JsonResult jsonResult;

            byte[] file = System.IO.File.ReadAllBytes(Server.MapPath("~/Content/web/pdfViewer/DPLsample.pdf"));
            FixedDocument doc = FixedDocument.Load(file, true);

            if (pageNumber == null)
            {
                jsonResult = Json(doc.ToJson(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                jsonResult = Json(doc.GetPage((int)pageNumber), JsonRequestBehavior.AllowGet);
            }


            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        public ActionResult GetPdf(HttpPostedFileBase file)
        {
            byte[] data;
            using (Stream inputStream = file.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                data = memoryStream.ToArray();
            }
            FixedDocument dox = FixedDocument.Load(data);

            var resultData = dox.ToJson();

            var result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(resultData),
                ContentType = "application/json"
            };

            return result;
        }
    }
}
