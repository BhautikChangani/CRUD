using System.IO;
using System.Web.Mvc;
using System;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf;
using Telerik.Windows.Documents.Fixed.FormatProviders.Pdf.Streaming;
using Telerik.Windows.Documents.Fixed.Model;

namespace Kendo.Mvc.Examples.Controllers.Signature
{
    public partial class SignatureController : Controller
    {
        [Demo]
        public ActionResult Sign_Pdf_Document()
        {
            return View();
        }
        public string PreparePdf(string pdfData)
        {
            byte[] resultingBytes = null;
            byte[] finalBytes = null;

            PdfFormatProvider provider = new PdfFormatProvider();
            byte[] renderedBytes = Convert.FromBase64String(pdfData);

            RadFixedDocument document1 = null;
            RadFixedDocument document2 = provider.Import(renderedBytes);

            string filePath = Server.MapPath("~/Content/web/signature/certificate.pdf");

            using (FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                document1 = provider.Import(input);
            }

            using (MemoryStream ms = new MemoryStream())
            {
                provider.Export(document1, ms);
                resultingBytes = ms.ToArray();
            }

            finalBytes = AppendContent(resultingBytes, document2);
            string result = Convert.ToBase64String(finalBytes);

            return result;
        }
        private byte[] AppendContent(byte[] resultingBytes, RadFixedDocument document2)
        {
            RadFixedPage foregroundContentOwner = document2.Pages[0];

            MemoryStream ms = new MemoryStream();
            byte[] renderedBytes = null;
            using (MemoryStream stream = new MemoryStream(resultingBytes))
            {
                using (PdfFileSource fileSource = new PdfFileSource(stream))
                {
                    using (PdfStreamWriter fileWriter = new PdfStreamWriter(ms, true))
                    {
                        foreach (PdfPageSource pageSource in fileSource.Pages)
                        {
                            using (PdfPageStreamWriter pageWriter = fileWriter.BeginPage(pageSource.Size, pageSource.Rotation))
                            {
                                pageWriter.WriteContent(pageSource);

                                using (pageWriter.SaveContentPosition())
                                {
                                    double xCenteringTranslation = (pageSource.Size.Width - foregroundContentOwner.Size.Width) - 320;
                                    double yCenteringTranslation = (pageSource.Size.Height - foregroundContentOwner.Size.Height) - 110;
                                    pageWriter.ContentPosition.Translate(xCenteringTranslation, yCenteringTranslation);
                                    pageWriter.WriteContent(foregroundContentOwner);
                                }
                            }
                        }
                    }
                }
            }
            renderedBytes = ms.ToArray();
            return renderedBytes;
        }
    }
}