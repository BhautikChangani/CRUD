using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Telerik.Documents.Common.Model;
using Telerik.Documents.Core.Fonts;
using Telerik.Documents.Media;
using Telerik.Documents.Primitives;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Editing;
using Telerik.Windows.Documents.Flow.Model.Styles;
using Telerik.Windows.Documents.Spreadsheet.Model;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WordsProcessingController : Controller
    {
        private static readonly ThemableColor GreenColor = new ThemableColor(Color.FromArgb(255, 92, 230, 0));

        [Demo]
        public ActionResult Generate_Documents()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create_Document(bool includeHeader, bool includeFooter, string fileType)
        {
            // Creating the document and populating its content
            var document = CreateDocument(includeHeader, includeFooter);

            // Creating the proper FormatProvider which will return the document in the selected format
            IFormatProvider<RadFlowDocument> formatProvider = null;
            string mimeType = String.Empty;
            string fileDownloadName = "{0}.{1}";

            switch (fileType)
            {
                case "docx":
                    formatProvider = new DocxFormatProvider();
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    break;
                case "rtf":
                    formatProvider = new RtfFormatProvider();
                    mimeType = "application/rtf";
                    break;
                case "html":
                    formatProvider = new HtmlFormatProvider();
                    mimeType = "text/html";
                    break;
                case "txt":
                    formatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
                    break;
                default:
                    formatProvider = new TxtFormatProvider();
                    mimeType = "text/plain";
                    break;
            }

            fileDownloadName = String.Format(fileDownloadName, "SampleDocument", fileType);

            byte[] renderedBytes = null;

            // Loading the document in Stream
            using (MemoryStream ms = new MemoryStream())
            {
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, mimeType, fileDownloadName);
        }

        private RadFlowDocument CreateDocument(bool includeHeader, bool includeFooter)
        {
            // Creating the Document, the Editor and the Paragraph formatting
            RadFlowDocument document = new RadFlowDocument();
            RadFlowDocumentEditor editor = new RadFlowDocumentEditor(document);
            editor.ParagraphFormatting.TextAlignment.LocalValue = Alignment.Justified;

            // Creating Body
            editor.InsertLine("Dear Telerik User,");
            editor.InsertText("We’re happy to introduce the new Telerik WordsProcessing component for ASP.NET MVC suit. High performance library that enables you to read, write and manipulate documents in DOCX, RTF and plain text format. The document model is independent from UI and ");
            Run run = editor.InsertText("does not require");
            run.Underline.Pattern = UnderlinePattern.Single;
            editor.InsertLine(" Microsoft Office.");

            editor.InsertText("The current community preview version comes with full rich-text capabilities including ");
            editor.InsertText("bold, ").FontWeight = FontWeights.Bold;
            editor.InsertText("italic, ").FontStyle = FontStyles.Italic;
            editor.InsertText("underline,").Underline.Pattern = UnderlinePattern.Single;
            editor.InsertText(" font sizes and ").FontSize = 20;
            editor.InsertText("colors ").ForegroundColor = GreenColor;

            editor.InsertLine("as well as text alignment and indentation. Other options include tables, hyperlinks, inline and floating images. Even more sweetness is added by the built-in styles and themes.");

            editor.InsertText("Here at Telerik we strive to provide the best services possible and fulfill all needs you as a customer may have. We would appreciate any feedback you send our way through the ");
            editor.InsertHyperlink("public forums", "https://www.telerik.com/forums", false, "Telerik Forums");
            editor.InsertLine(" or support ticketing system.");

            editor.InsertLine("We hope you’ll enjoy RadWordsProcessing as much as we do. Happy coding!");
            editor.InsertText("Kind regards,");

            CreateSignature(editor);

            if (includeHeader)
            {
                CreateHeader(editor);
            }

            if (includeFooter)
            {
                CreateFooter(editor);
            }

            return document;
        }

        private void CreateSignature(RadFlowDocumentEditor editor)
        {
            // Creating the signature table
            Table signatureTable = editor.InsertTable(1,1);
            signatureTable.Rows[0].Cells[0].Borders = new TableCellBorders(
                new Border(4, BorderStyle.Single, GreenColor),
                new Border(BorderStyle.None),
                new Border(BorderStyle.None),
                new Border(BorderStyle.None));

            // Creating single cell with name and position
            signatureTable.Rows[0].Cells[0].PreferredWidth = new TableWidthUnit(140);
            signatureTable.Rows[0].Cells[0].Padding = new Telerik.Windows.Documents.Primitives.Padding(12, 0, 0, 0);
            Paragraph cellParagraph = signatureTable.Rows[0].Cells[0].Blocks.AddParagraph();
            cellParagraph.Spacing.SpacingAfter = 0;
            editor.MoveToParagraphStart(cellParagraph);
            editor.CharacterFormatting.FontSize.LocalValue = 12;

            editor.InsertText("Jane Doe").FontWeight = FontWeights.Bold;
            editor.InsertParagraph().Spacing.SpacingAfter = 0;
            editor.InsertText("Support Officer");
        }

        private void CreateFooter(RadFlowDocumentEditor editor)
        {
            // Creating Footer paragraph with top border styling
            Footer footer = editor.Document.Sections.First().Footers.Add();
            Paragraph paragraph = footer.Blocks.AddParagraph();
            paragraph.TextAlignment = Alignment.Right;
            paragraph.Borders = new ParagraphBorders(
                new Border(BorderStyle.None),
                new Border(3, BorderStyle.Single, GreenColor),
                new Border(BorderStyle.None),
                new Border(BorderStyle.None));

            editor.MoveToParagraphStart(paragraph);
            editor.InsertHyperlink("www.telerik.com", "https://www.telerik.com", false, "Telerik Site");
        }

        private void CreateHeader(RadFlowDocumentEditor editor)
        {
            // Creating Header with an image
            Header header = editor.Document.Sections.First().Headers.Add();
            editor.MoveToParagraphStart(header.Blocks.AddParagraph());
            string fileName = Server.MapPath("~/Content/web/wordsprocessing/DocumentsPicture.png");
            using (Stream stream = System.IO.File.OpenRead(fileName))
            {
                editor.InsertImageInline(stream, "png", new Size(289.2, 160.2));
            }
        }
    }
}
