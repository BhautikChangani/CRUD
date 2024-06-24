using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Export;
using Telerik.Windows.Documents.Fixed.Model;
using Telerik.Windows.Documents.Fixed.Model.Annotations;
using Telerik.Windows.Documents.Fixed.Model.ColorSpaces;
using Telerik.Windows.Documents.Fixed.Model.DigitalSignatures;
using Telerik.Windows.Documents.Fixed.Model.Editing;
using Telerik.Windows.Documents.Fixed.Model.InteractiveForms;
using Telerik.Windows.Documents.Fixed.Model.Objects;
using Telerik.Windows.Documents.Fixed.Model.Resources;


namespace Kendo.Mvc.Examples.Controllers
{
    public partial class PdfProcessingController : Controller
    {
        [Demo]
        public ActionResult Sign_Pdf_Document()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Sign_PDF_Document()
        {
            string fileDownloadName = "test.pdf";
            string mimeType = String.Empty;
            string fileName = Server.MapPath("~/Content/web/pdfprocessing/Unsigned.pdf");
            using (FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                RadFixedDocument document = new PdfFormatProvider().Import(input);

                fileDownloadName = String.Format(fileDownloadName, "SampleDocument", "pdf");

                PdfFormatProvider formatProvider = new PdfFormatProvider();
                formatProvider.ExportSettings.ImageQuality = ImageQuality.High;
                mimeType = "application/pdf";




                string fileNamePfx = Server.MapPath("~/Content/web/pdfprocessing/JohnDoe.pfx");
                byte[] fileAllBytes;
                using (FileStream inputPxf = new FileStream(fileNamePfx, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        inputPxf.CopyTo(ms);
                        fileAllBytes = ms.ToArray();
                    }

                    AddSignature(document, fileAllBytes);
                }

                byte[] renderedBytes = null;

                using (MemoryStream ms = new MemoryStream())
                {
                    formatProvider.Export(document, ms);
                    renderedBytes = ms.ToArray();
                }


                return File(renderedBytes, mimeType, fileDownloadName);
            }
        }

        private static void AddSignature(RadFixedDocument document, byte[] certificateFileBytes)
        {
            FormSource formSource = new FormSource();

            var certificate = new X509Certificate2(certificateFileBytes, "johndoe");
            SignatureField signatureField = document.AcroForm.FormFields.Where(f => f.FieldType == FormFieldType.Signature).FirstOrDefault() as SignatureField;
            signatureField.Signature = new Telerik.Windows.Documents.Fixed.Model.DigitalSignatures.Signature(certificate);

            SignatureWidget widget = signatureField.Widgets.FirstOrDefault();
            if (widget != null)
            {
                formSource = widget.Content.NormalContentSource;

                FixedContentEditor ed = new FixedContentEditor(formSource);
                ed.TextProperties.FontSize = 80;
                ed.Position.Translate(30, 0);
                ed.DrawText("John Doe");
                ed.Position.Translate(0, 90);
                ed.TextProperties.FontSize = 25;
                ed.DrawText("Digitally signed on: " + DateTime.Now.ToString());
                ed.Position.Translate(40, 120);
                ed.TextProperties.FontSize = 20;
                ed.DrawText("(Click here to view the signature info)");
            }

            document.Pages[0].Annotations.Add(widget);
        }
    }
}
