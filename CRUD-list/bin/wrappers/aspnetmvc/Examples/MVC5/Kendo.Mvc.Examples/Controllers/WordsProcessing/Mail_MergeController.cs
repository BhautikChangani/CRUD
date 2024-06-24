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
        private static readonly ThemableColor ColorGreen = new ThemableColor(Color.FromArgb(255, 92, 230, 0));

        [Demo]
        public ActionResult Mail_Merge()
        {

            return View();
        }

        [HttpPost]
        public ActionResult MailMerge(string fileFormat, IEnumerable<string> recepients)
        {
            RadFlowDocument document = this.CreateDocument();

            RadFlowDocument mailMergeDocument = document.MailMerge(GetRecipients(recepients));
            mailMergeDocument.DocumentVariables.Add("sender", "Telerik Team");
            mailMergeDocument.UpdateFields();

            return SaveDocument(mailMergeDocument, fileFormat);
        }

        private ActionResult SaveDocument(RadFlowDocument document, string fileFormat)
        {

            IFormatProvider<RadFlowDocument> formatProvider = null;
            string mimeType = String.Empty;
            string fileDownloadName = "{0}.{1}";

            switch (fileFormat)
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

            fileDownloadName = String.Format(fileDownloadName, "SampleDocument", fileFormat);

            byte[] renderedBytes = null;

            using (MemoryStream ms = new MemoryStream())
            {
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, mimeType, fileDownloadName);
        }

        private RadFlowDocument CreateDocument()
        {
            RadFlowDocument document = new RadFlowDocument();
            RadFlowDocumentEditor editor = new RadFlowDocumentEditor(document);
            editor.ParagraphFormatting.TextAlignment.LocalValue = Alignment.Justified;

            editor.InsertText("Dear ");
            editor.InsertField("MERGEFIELD Name", "");
            editor.InsertLine(",");
            editor.InsertLine("We're happy to introduce the WordsProcessing component in the UI for ASP.NET MVC suite. High performance library that enables you to read, write and manipulate documents in DOCX, RTF, HTML and plain text format.");

            editor.InsertText("The current beta version comes with full rich-text capabilities including ");
            editor.InsertText("bold, ").FontWeight = FontWeights.Bold;
            editor.InsertText("italic, ").FontStyle = FontStyles.Italic;
            Run underlined = editor.InsertText("underline,");
            underlined.Underline.Pattern = UnderlinePattern.Single;
            underlined.Underline.Color = new ThemableColor(Colors.Black);
            editor.InsertText(" font sizes and ").FontSize = 20;
            editor.InsertText("colors ").ForegroundColor = ColorGreen;
            editor.InsertLine("as well as text alignment and indentation. Other options include tables, lists, hyperlinks, bookmarks and comments, inline and floating images. Even more sweetness is added by the built-in styles and themes.");

            editor.InsertLine("We hope you'll enjoy WordsProcessing as much as we do. Happy coding!");

            editor.InsertParagraph().Spacing.SpacingAfter = 0;
            editor.InsertLine("Regards,");
            editor.InsertField("DOCVARIABLE sender", "");

            return document;
        }

        private List<Person> GetRecipients(IEnumerable<string> ids )
        {
            List<Person> people = new List<Person>();

            people.Add(new Person("Nancy Davolio", "1"));
            people.Add(new Person("Andrew Fuller", "2"));
            people.Add(new Person("Janet Leverling", "3"));
            people.Add(new Person("Margaret Peacock", "4"));
            people.Add(new Person("Steven Buchanan", "5"));

            List<Person> selectedPeople = new List<Person>();

            foreach (var id in ids) {
                selectedPeople.Add(people.Where(p => p.Id == id).FirstOrDefault());
            }

            return selectedPeople;
        }
    }

    public class Person
    {
        public Person(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }

    }
}