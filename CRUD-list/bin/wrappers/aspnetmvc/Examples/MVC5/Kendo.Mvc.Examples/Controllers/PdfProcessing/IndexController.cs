using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Documents.ImageUtils;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PdfProcessingController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Download_Document()
        {
            PdfFormatProvider formatProvider = new PdfFormatProvider();
            formatProvider.ExportSettings.ImageQuality = ImageQuality.High;

            ImagePropertiesResolver defaultImagePropertiesResolver = new ImagePropertiesResolver();
            Telerik.Windows.Documents.Extensibility.FixedExtensibilityManager.ImagePropertiesResolver = defaultImagePropertiesResolver;

            byte[] renderedBytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                RadFixedDocument document = CreatePdfDocument.CreateDocument();
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, "application/pdf", "PdfDocument.pdf");
        }
    }
}
