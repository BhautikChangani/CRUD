using Kendo.Extensions;
using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public class DemoAttribute : ActionFilterAttributeBase
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);


            FindCurrentExample();

            NavigationExample currentExample = ViewBag.CurrentExample;
            NavigationWidget currentWidget = ViewBag.CurrentWidget;

            if (currentWidget == null)
            {
                return;
            }

            Dictionary<string, string> marketingLinks =
            new Dictionary<string, string>();
            marketingLinks.Add("FileManager", "https://www.telerik.com/aspnet-mvc/file-manager");
            marketingLinks.Add("PivotGridV2", "https://www.telerik.com/aspnet-mvc/pivotgrid-v.2");
            marketingLinks.Add("AppBar", "https://www.telerik.com/aspnet-mvc/app-bar");
            marketingLinks.Add("ButtonGroup", "https://www.telerik.com/aspnet-mvc/button-group");
            marketingLinks.Add("Drawer", "https://www.telerik.com/aspnet-mvc/drawer-widget");
            marketingLinks.Add("MediaPlayer", "https://www.telerik.com/aspnet-mvc/media-player-for-mvc");
            marketingLinks.Add("ScrollView", "https://www.telerik.com/aspnet-mvc/mvc-scrollview");
            marketingLinks.Add("QRCode", "https://www.telerik.com/aspnet-mvc/qr-code");
            marketingLinks.Add("DateRangePicker", "https://www.telerik.com/aspnet-mvc/mvc-daterangepicker");
            marketingLinks.Add("ImageEditor", "https://www.telerik.com/aspnet-mvc/image-editor");
            marketingLinks.Add("Switch", "https://www.telerik.com/aspnet-mvc/mvc-switch");
            marketingLinks.Add("TextArea", "https://www.telerik.com/aspnet-mvc/text-area");
            marketingLinks.Add("Chat", "https://www.telerik.com/aspnet-mvc/conversational-ui");
            marketingLinks.Add("Arc Gauge", "https://www.telerik.com/aspnet-mvc/arcgauge");
            marketingLinks.Add("Linear Gauge", "https://www.telerik.com/aspnet-mvc/lineargauge");
            marketingLinks.Add("Radial Gauge", "https://www.telerik.com/aspnet-mvc/radialgauge");
            marketingLinks.Add("PDFViewer", "https://www.telerik.com/aspnet-mvc/pdf-viewer");
            marketingLinks.Add("MultiViewCalendar", "https://www.telerik.com/aspnet-mvc/mvc-multiviewcalendar");
            marketingLinks.Add("Gantt", "https://www.telerik.com/aspnet-mvc/ganttchart");
            marketingLinks.Add("SkeletonContainer", "https://www.telerik.com/aspnet-mvc/skeleton");
            marketingLinks.Add("Circular ProgressBar", "https://www.telerik.com/aspnet-mvc/circular-progress-bar");
            marketingLinks.Add("Ripple Container", "https://www.telerik.com/aspnet-mvc/mvc-ripple");
            marketingLinks.Add("SpreadProcessing", "https://www.telerik.com/aspnet-mvc/radspreadprocessing-mvc");
            marketingLinks.Add("SpreadStreamProcessing", "https://www.telerik.com/aspnet-mvc/mvc-spreadstreamprocessing");
            marketingLinks.Add("WordsProcessing", "https://www.telerik.com/aspnet-mvc/mvc-words-processing");
            marketingLinks.Add("PdfProcessing", "https://www.telerik.com/aspnet-mvc/mvc-pdfprocessing");
            marketingLinks.Add("Chart", "https://www.telerik.com/aspnet-mvc/charts");
            marketingLinks.Add("Stock Charts", "https://www.telerik.com/aspnet-mvc/stock-chart");
            marketingLinks.Add("Pyramid Charts", "https://www.telerik.com/aspnet-core-ui/pyramid-chart");
            marketingLinks.Add("Zip Library", "https://www.telerik.com/aspnet-mvc/ziplibrary");
            marketingLinks.Add("Dialog", "https://www.telerik.com/aspnet-mvc/dialog-for-mvc");
            marketingLinks.Add("CheckBox", "n/a");
            marketingLinks.Add("PivotGrid", "n/a");
            marketingLinks.Add("RadioButton", "n/a");
            marketingLinks.Add("Validator", "n/a");
            marketingLinks.Add("PDF Export", "n/a");
            marketingLinks.Add("Cards", "n/a");
            marketingLinks.Add("Drag and Drop", "n/a");
            marketingLinks.Add("Area Charts", "n/a");
            marketingLinks.Add("Bar Charts", "n/a");
            marketingLinks.Add("Box Plot Charts", "n/a");
            marketingLinks.Add("Bubble Charts", "n/a");
            marketingLinks.Add("Bullet Charts", "n/a");
            marketingLinks.Add("Chart API", "n/a");
            marketingLinks.Add("Donut Charts", "n/a");
            marketingLinks.Add("Funnel Charts", "n/a");
            marketingLinks.Add("Line Charts", "n/a");
            marketingLinks.Add("Pie Charts", "n/a");
            marketingLinks.Add("Polar Charts", "n/a");
            marketingLinks.Add("Radar Charts", "n/a");
            marketingLinks.Add("Range Bar Charts", "n/a");
            marketingLinks.Add("Scatter Charts", "n/a");
            marketingLinks.Add("Sparklines", "n/a");
            marketingLinks.Add("Waterfall Charts", "n/a");
            marketingLinks.Add("DataSource", "n/a");
            marketingLinks.Add("Reporting Integration", "n/a");
            marketingLinks.Add("Range Area Charts", "n/a");
            marketingLinks.Add("DrillDown Charts", "n/a");

            // List of overview revamped demos
            List<string> overviewDemos = new List<string>() {
                "autocomplete/index",
                "combobox/index",
                "dropdownlist/index",
                "dropdowntree/index",
                "multicolumncombobox/index",
                "multiselect/index",
                "dateinput/index",
                "datepicker/index",
                "datetimepicker/index",
                "daterangepicker/index",
                "timepicker/index",
                "colorpicker/index",
                "colorgradient/index",
                "flatcolorpicker/index",
                "textbox/index",
                "maskedtextbox/index",
                "numerictextbox/index",
                "textarea/index"
            };

            ViewBag.Framework = "ASP.NET MVC";
            ViewBag.Description = Description(ViewBag.Product, currentExample, currentWidget);
            ViewBag.CtaType = GetCtaType(currentExample, currentWidget);
            ViewBag.HasConsole = currentExample.HasConsole;
            ViewBag.UniqueLinks = marketingLinks;
            ViewBag.IsOverView = overviewDemos.Contains(currentExample.Url) ? "kd-overview" : "";

            var exampleFiles = new List<ExampleFile>();
            exampleFiles.AddRange(SourceCode());
            exampleFiles.AddRange(AdditionalSources(currentWidget.Sources));
            exampleFiles.AddRange(AdditionalSources(currentExample.Sources));
            ViewBag.ExampleFiles = exampleFiles.Where(file => file.Exists(Controller.Server)).ToList();

            var api = currentExample.Api ?? ViewBag.CurrentWidget.Api;
            if (!string.IsNullOrEmpty(api))
            {
                if (!api.Contains("https://docs") && !ViewBag.CurrentWidget.HideClientApi)
                {
                    ViewBag.ClientApi = "https://docs.telerik.com/kendo-ui/api/" + api;
                }

                if (api == "web/validator")
                {
                    ViewBag.Api = "https://docs.telerik.com/kendo-ui/aspnet-mvc/validation";
                }
                else
                {
                    ViewBag.Api = UrlExtensions.IsAbsoluteUrl(api) ? api : "https://docs.telerik.com/kendo-ui/api/wrappers/aspnet-mvc/kendo.mvc.ui.fluent" + Regex.Replace(api, "(web|dataviz|framework)", "").Replace("mobile/", "/mobile") + "builder";
                }
            }

            if (currentWidget.Documentation != null && currentWidget.Documentation.ContainsKey(ViewBag.Product))
            {
                var documentationLink = currentWidget.Documentation[ViewBag.Product];
                ViewBag.Documentation = UrlExtensions.IsAbsoluteUrl(documentationLink) ? documentationLink : "https://docs.telerik.com/aspnet-mvc/" + documentationLink;
            }

            if (currentWidget.Forum != null && currentWidget.Forum.ContainsKey(ViewBag.Product))
            {
                ViewBag.Forum = "https://www.telerik.com/forums/" + currentWidget.Forum[ViewBag.Product];
            }

            //if (currentWidget.CodeLibrary != null && currentWidget.CodeLibrary.ContainsKey(ViewBag.Product))
            //{
            //    ViewBag.CodeLibrary = "https://www.telerik.com/support/code-library/" + currentWidget.CodeLibrary[ViewBag.Product];
            //}
        }

        protected void FindCurrentExample()
        {
            var found = false;

            NavigationExample current = null;
            NavigationWidget currentWidget = null;

            if (ViewBag.Navigation != null)
            {
                foreach (NavigationWidget widget in ViewBag.Navigation)
                {
                    List<NavigationExample> navigationExamples = widget.Groups.SelectMany(x => x.Items).ToList();
                    foreach (NavigationExample example in navigationExamples.Concat(widget.Items))
                    {
                        if (!found && IsCurrentExample(example.Url))
                        {
                            current = example;
                            currentWidget = widget;
                            found = true;
                            LoadAltDescription(example);
                        }
                    }
                }
            }

            ViewBag.CurrentWidget = currentWidget;

            if (currentWidget == null)
            {
                return;
            }

            ViewBag.CurrentExample = current;

            if (current.Url.Contains("index"))
            {
                ViewBag.Title = string.Format("Demo for core features in ASP.NET MVC {0} control | Telerik UI for ASP.NET MVC", currentWidget.Text);
                ViewBag.IsOverviewPage = true;
            }
            else if(current.Url.Contains("appearance"))
            {
                ViewBag.IsAppearancePage = true;
            }
            else
            {
                ViewBag.Title = string.Format("ASP.NET MVC {0} {1} Demo | Telerik UI for ASP.NET MVC" , currentWidget.Text, current.Text);
            }


            if (current.Meta != null)
            {
                if (current.Meta.ContainsKey("aspnet-mvc"))
                {
                    ViewBag.Meta = current.Meta["aspnet-mvc"];
                }
            }
            else
            {
                ViewBag.Meta = string.Format("This demo shows how to use {0} for ASP.NET MVC {1}. Play with the example or check the source code.", current.Text, currentWidget.Text); ;
            }
        }

        private bool IsCurrentExample(string url)
        {
            var section = Controller.ControllerContext.RouteData.GetRequiredString("controller").ToLower().Replace("_", "-");
            var example = Controller.ControllerContext.RouteData.GetRequiredString("action").ToLower().Replace("_", "-");

             var components = url.Split('/');

            return (section == components[0] && example == components[1]) || (section == "upload" && example == "result" && components[0] == "upload" && components[1] == "index");
        }

        protected string Description(string product, NavigationExample example, NavigationWidget widget)
        {
            if (example.Description != null && example.Description.ContainsKey(product))
            {
                return example.Description[product];
            }
            else if (widget.Description != null && widget.Description.ContainsKey(product))
            {
                return widget.Description[product];
            }

            return null;
        }

        protected string GetCtaType(NavigationExample example, NavigationWidget widget)
        {
            var restricted = new List<string>() { "Document Processing", "Reporting", "Framework" };

            if (!restricted.Contains(widget.Category) && example.Url.Contains("index"))
            {
                return "large";
            }

            return "small";
        }

        protected IEnumerable<ExampleFile> SourceCode()
        {
            var section = Controller.ControllerContext.RouteData.GetRequiredString("controller").ToLower().Replace("_", "-");
            var example = Controller.ControllerContext.RouteData.GetRequiredString("action").ToLower().Replace("_", "-");

            IFrameworkDescription framework = new AspNetMvcDescription();

            return framework.GetFiles(Controller.Server, example, section);
        }

        protected IEnumerable<ExampleFile> AdditionalSources(IDictionary<string, IEnumerable<ExampleFile>> sources)
        {
            var files = new List<ExampleFile>();

            if (sources != null && sources.ContainsKey("aspnet-mvc"))
            {
                files.AddRange(sources["aspnet-mvc"]);
            }

            return files;
        }

        private void LoadAltDescription(NavigationExample example)
        {
            var segments = example.Url.Split(new char[] { '/' });
            segments[0] = segments[0].Replace("-", "_");
            var url = string.Join("/", segments);
            var path = Controller.Server.MapPath("~/Views/" + url + ".html");
            if (System.IO.File.Exists(path))
            {
                example.AltDescription = System.IO.File.ReadAllText(path);
            }
        }

    }
}