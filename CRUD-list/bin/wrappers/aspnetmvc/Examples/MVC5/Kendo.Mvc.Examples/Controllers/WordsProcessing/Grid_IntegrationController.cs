using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.WordsProcessing;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Windows.Media;
using TelerikMedia = Telerik.Documents.Media;
using Telerik.Documents.Common.Model;
using Telerik.Windows.Documents.Common.FormatProviders;
using Telerik.Windows.Documents.Flow.FormatProviders.Docx;
using Telerik.Windows.Documents.Flow.FormatProviders.Html;
using Telerik.Windows.Documents.Flow.FormatProviders.Rtf;
using Telerik.Windows.Documents.Flow.FormatProviders.Txt;
using Telerik.Windows.Documents.Flow.Model;
using Telerik.Windows.Documents.Flow.Model.Styles;
using Telerik.Windows.Documents.Spreadsheet.Model;
using Telerik.Documents.Core.Fonts;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WordsProcessingController : Controller
    {
        // Predefined width for the columns in the table and no data message
        private static readonly int WidthOfIndentColumns = 10;
        private static readonly int WidthOfRegularColumns = 150;
        private static readonly string NoDataMessage = "There is no data to be displayed in the Grid";

        // Fields to hold data about the coloting of the table rows
        private static TelerikMedia.Color RowBackgroundColor;
        private static TelerikMedia.Color GroupHeaderBackgroundColor;
        private static TelerikMedia.Color HeaderBackgroundColor;

        [Demo]
        public ActionResult Grid_Integration()
        {
            return View();
        }

        public ActionResult GridIntegration_Read([DataSourceRequest] DataSourceRequest request)
        {
            // Save the request configuration to be used later during the document generation
            HttpContext.Session["request"] = request;

            return Json(productService.Read().ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult DocumentFromGrid(DocumentDescriptionViewModel data)
        {
            // Retrieve data from the DocumentDescriptionViewModel and the Product service
            var request = HttpContext.Session["request"] as DataSourceRequest;
            var columns = JsonConvert.DeserializeObject<IList<ColumnsViewModel>>(data.Columns);
            var allProducts = productService.Read();
            var resultData = allProducts.ToDataSourceResult(request);

            // Set the background values
            RowBackgroundColor = TelerikMedia.Color.FromHex(data.RowBackground);
            GroupHeaderBackgroundColor = TelerikMedia.Color.FromHex(data.GroupHeaderBackground);
            HeaderBackgroundColor = TelerikMedia.Color.FromHex(data.HeaderBackground);

            // Create the RadFlowDocument
            RadFlowDocument document = CreateDocument(data.RepeateHeader, columns, resultData);

            // Create the provider
            IFormatProvider<RadFlowDocument> formatProvider = null;
            string mimeType = String.Empty;
            switch (data.FileType)
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

            string fileDownloadName = "{0}.{1}";
            fileDownloadName = String.Format(fileDownloadName, "SampleDocument", data.FileType);

            byte[] renderedBytes = null;

            // Export the created document to byte array
            using (MemoryStream ms = new MemoryStream())
            {
                formatProvider.Export(document, ms);
                renderedBytes = ms.ToArray();
            }

            return File(renderedBytes, mimeType, fileDownloadName);
        }

        private RadFlowDocument CreateDocument(bool repeateHeader, IList<ColumnsViewModel> columns, DataSourceResult result)
        {
            // Create new document and insert a table in it
            RadFlowDocument document = new RadFlowDocument();
            Table table = document.Sections.AddSection().Blocks.AddTable();

            document.StyleRepository.AddBuiltInStyle(BuiltInStyleNames.TableGridStyleId);
            table.StyleId = BuiltInStyleNames.TableGridStyleId;

            int groupingLevels = 0;
            var resultDataAsQueriable = result.Data.AsQueryable();

            // Check if the Grid data contains any items
            if (resultDataAsQueriable.Count() > 0)
            {
                var firstObjectItem = resultDataAsQueriable.ElementAt(0);

                // Check if the Grid data contains any Groups and how many levels they have
                for (int i = 0; i < columns.Count; i++)
                {
                    var resultItem = firstObjectItem as ProductViewModel;
                    if (resultItem != null)
                    {
                        break;
                    }
                    else
                    {
                        groupingLevels += 1;
                        firstObjectItem = (firstObjectItem as AggregateFunctionsGroup).Items.AsQueryable().ElementAt(0);
                    }
                }
            }
            
            // Create the header row
            TableRow headerRow = table.Rows.AddTableRow();
            headerRow.RepeatOnEveryPage = repeateHeader;
            ThemableColor headerBackground = new ThemableColor(HeaderBackgroundColor);

            // Indent header row text if grouping is present
            if (groupingLevels > 0)
            {
                for (int i = 0; i < groupingLevels; i++)
                {
                    AddIndentCell(headerRow, headerBackground);
                }
            }

            // Popoulate header row text
            for (int i = 0; i < columns.Count; i++)
            {
                TableCell cell = headerRow.Cells.AddTableCell();
                cell.Shading.BackgroundColor = headerBackground;
                cell.PreferredWidth = new TableWidthUnit(WidthOfRegularColumns);
                Run headerRun = cell.Blocks.AddParagraph().Inlines.AddRun(columns[i].Title);
                headerRun.FontWeight = FontWeights.Bold;
            }

            if (groupingLevels > 0)
            {
                // Populate Group headers
                var allAgregates = (result.Data as IEnumerable<AggregateFunctionsGroup>).ToList();
                int numberOfAggregates = allAgregates.Count;

                for (int i = 0; i < numberOfAggregates; i++)
                {
                    var currentAgregate = allAgregates[i];
                    AddGroupRow(table, currentAgregate, columns, groupingLevels, 1);
                }
            }
            else if (resultDataAsQueriable.Count() > 0)
            {
                // Populate the items, if no grouping is present
                var productsList = (result.Data as IEnumerable<ProductViewModel>).ToList();
                AddDataRows(table, productsList, columns, groupingLevels);
            }
            else
            {
                // Set no data message
                TableRow noDataRow = table.Rows.AddTableRow();
                TableCell noDataCell = noDataRow.Cells.AddTableCell();
                noDataCell.Shading.BackgroundColor = new ThemableColor(RowBackgroundColor);
                noDataCell.ColumnSpan = columns.Count;
                AddCellValue(noDataCell, NoDataMessage);
            }

            document.Sections.First().Blocks.AddParagraph();

            return document;
        }

        private void AddIndentCell(TableRow row, ThemableColor background)
        {
            TableCell indentCell = row.Cells.AddTableCell();
            indentCell.PreferredWidth = new TableWidthUnit(WidthOfIndentColumns);
            indentCell.Shading.BackgroundColor = background;
            indentCell.Blocks.AddParagraph();
        }

        private void AddGroupRow(Table table, AggregateFunctionsGroup groupedData, IList<ColumnsViewModel> columns, int groupingLevels, int currentLevel)
        {
            TableRow row = table.Rows.AddTableRow();
            ThemableColor GroupHeaderBackground = new ThemableColor(GroupHeaderBackgroundColor);

            // Indent Group header row text
            for (int i = 0; i < currentLevel; i++)
            {
                AddIndentCell(row, GroupHeaderBackground);
            }

            // Populate Group header row text
            TableCell cell = row.Cells.AddTableCell();
            cell.Shading.BackgroundColor = GroupHeaderBackground;
            cell.ColumnSpan = columns.Count + groupingLevels - currentLevel;
            AddCellValue(cell, groupedData.Member + ": " + groupedData.Key.ToString());

            var products = groupedData.Items as IEnumerable<ProductViewModel>;

            if (products == null)
            {
                // Populate nested Group headers
                var aggregates = groupedData.Items as IEnumerable<AggregateFunctionsGroup>;

                foreach (var group in aggregates)
                {
                    AddGroupRow(table, group, columns, groupingLevels, currentLevel + 1);
                }
            }
            else
            {
                // Populate the items, if no more nested groups are present
                AddDataRows(table, products.ToList(), columns, groupingLevels);
            }
        }

        private void AddDataRows(Table table, IList<ProductViewModel> items, IList<ColumnsViewModel> columns, int groupingLevels)
        {
            ThemableColor background = new ThemableColor(RowBackgroundColor);

            for (int i = 0; i < items.Count; i++)
            {
                TableRow row = table.Rows.AddTableRow();

                // Indent row text according to grouping
                if (groupingLevels > 0)
                {
                    for (int j = 0; j < groupingLevels; j++)
                    {
                        AddIndentCell(row, background);
                    }
                }

                // Populate row text
                for (int j = 0; j < columns.Count; j++)
                {
                    TableCell cell = row.Cells.AddTableCell();

                    PropertyInfo prop = typeof(ProductViewModel).GetProperty(columns[j].Field);
                    AddCellValue(cell, prop.GetValue(items[i], null));
                    cell.Shading.BackgroundColor = background;
                    cell.PreferredWidth = new TableWidthUnit(WidthOfRegularColumns);
                }
            }
        }

        private void AddCellValue(TableCell cell, object value)
        {
            string stringValue = value != null ? value.ToString() : string.Empty;
            cell.Blocks.AddParagraph().Inlines.AddRun(stringValue);
        }
    }
}
