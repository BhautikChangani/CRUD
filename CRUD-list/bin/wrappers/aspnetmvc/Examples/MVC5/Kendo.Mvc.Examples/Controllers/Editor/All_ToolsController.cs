using Kendo.Core.Export;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class EditorController : Controller
    {
        [Demo]
        public ActionResult All_Tools()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Export(EditorExportData data)
        {
            var settings = new EditorDocumentsSettings();
            settings.HtmlImportSettings.LoadImageFromUri += HtmlImportSettings_LoadFromUri;
            try
            {
                var result = EditorExport.Export(data, settings);


                return new FileStreamResult(result.FileStream, result.ContentType);
            }
            catch (Exception e)
            {
                return RedirectToAction("exportas", "editor");
            }
        }

        public ActionResult Import(HttpPostedFileBase file)
        {
            var settings = new EditorImportSettings();
            string htmlResult;
            var formFile = new FormFile(file.InputStream, 0, file.InputStream.Length, "streamFile", file.FileName);
            switch (Path.GetExtension(file.FileName))
            {
                case ".docx":
                    htmlResult = EditorImport.ToDocxImportResult(formFile, settings);
                    break;
                case ".rtf":
                    htmlResult = EditorImport.ToRtfImportResult(formFile, settings);
                    break;
                default:
                    htmlResult = EditorImport.GetTextContent(formFile);
                    break;
            }

            return Json(new { html = htmlResult });
        }

        private void HtmlImportSettings_LoadFromUri(object sender, Telerik.Windows.Documents.Flow.FormatProviders.Html.LoadImageFromUriEventArgs e)
        {
            var uri = e.Uri;
            var absoluteUrl = uri.StartsWith("http://") || uri.StartsWith("www.");
            if (!absoluteUrl)
            {

                var filePath = Server.MapPath(uri);
                using (var fileStream = System.IO.File.OpenRead(filePath))
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        var array = memoryStream.ToArray();
                        e.SetImageInfo(array, "png");
                    }
                }
            }
        }
    }
}