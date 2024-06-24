
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Kendo.Core.Export;

namespace Kendo.Mvc.Examples.Controllers
{
    public class EditorExportController : Controller
    {
        [HttpPost]
        public ActionResult Export(EditorExportData data)
        {
            var settings = new EditorDocumentsSettings();
            settings.HtmlImportSettings.LoadImageFromUri += HtmlImportSettings_LoadImageFromUri;
            try
            {
                var result = EditorExport.Export(data, settings);


                return new FileStreamResult(result.FileStream, result.ContentType);
            }
            catch
            {
                return RedirectToAction("exportas", "editor");
            }
        }

        private void HtmlImportSettings_LoadImageFromUri(object sender, Telerik.Windows.Documents.Flow.FormatProviders.Html.LoadImageFromUriEventArgs e)
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
                        e.SetImageInfo(memoryStream.ToArray(), "png");
                    }
                }
            }
        }    }
}
