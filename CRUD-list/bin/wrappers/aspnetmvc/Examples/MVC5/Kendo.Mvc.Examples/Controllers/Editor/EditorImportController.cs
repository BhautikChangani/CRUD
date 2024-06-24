using Kendo.Core.Export;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers.Editor
{
    public class EditorImportController : Controller
    {
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
    }
}
