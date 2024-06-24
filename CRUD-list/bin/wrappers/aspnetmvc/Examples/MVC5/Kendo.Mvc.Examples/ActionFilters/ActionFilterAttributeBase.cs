using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using IOFile = System.IO.File;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Themes;
using System.Configuration;
using Newtonsoft.Json;

namespace Kendo.Mvc.Examples.Controllers
{
    public abstract class ActionFilterAttributeBase : ActionFilterAttribute
    {
        private DemoCacheManager demoCacheManager = DemoCacheManager.Instance;
        protected static string Header = "";
        protected static string Footer = "";
        protected static string Banner = "";
        protected static bool ResetHeader = true;
        protected static bool ResetFooter = true;
        protected static string TelerikNavigationVersion = "stable";

        public dynamic ViewBag
        {
            get
            {
                return Controller.ViewBag;
            }
        }

        public Controller Controller { get; set; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            Controller = null;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Controller = filterContext.Controller as Controller;
            string Url = filterContext.HttpContext.Request.Url.AbsoluteUri;

            if (ResetHeader)
            {
                UpdateHeader(Url);
                UpdateBanner(Url);
            }
            if (ResetFooter)
            {
                UpdateFooter(Url);
            }

            ViewBag.ShowCodeStrip = true;
            ViewBag.Product = "aspnet-mvc";
            ViewBag.NavProduct = "mvc";
            ViewBag.TelerikNavigationHeader = Header;
            ViewBag.TelerikNavigationFooter = Footer;
            ViewBag.TelerikBannerHeader = Banner;
            ViewBag.AssetsCDN = ConfigurationManager.AppSettings["AssetsCDN"];

            SetFeedbackId();
            LoadThemes();
            SetTheme();
            LoadNavigation();
            LoadCategories();

            if (Url.IndexOf("updateteleriknavigation") != -1)
            {
                ResetHeader = true;
                ResetFooter = true;
            }
        }

        protected void LoadThemes()
        {
            ViewBag.LessThemes = demoCacheManager.LessThemes;
            ViewBag.SassThemes = demoCacheManager.SassThemes;
        }

        protected void SetTheme()
        {
            string theme = "default-ocean-blue";
            string accessibilityTheme = "default-ocean-blue-a11y";
            var request = Controller.HttpContext.Request;
            string themeParam = request.QueryString["theme"];
            var storedTheme = Controller.HttpContext.Session["theme"];
            var isAccessibility = !string.IsNullOrEmpty(request.Path) && request.Path.IndexOf("keyboard-navigation") >= 0;

            if (themeParam != null && Regex.IsMatch(themeParam, "[a-z0-9\\-]+", RegexOptions.IgnoreCase))
            {
                theme = themeParam;

                // update theme
                Controller.HttpContext.Session["theme"] = theme;
            }
            else if (storedTheme != null)
            {
                theme = storedTheme.ToString();
            }
            else if (isAccessibility)
            {
                theme = accessibilityTheme;
            }

            ViewBag.Theme = GetThemeModel(theme);
            ViewBag.IsSassTheme = IsSassTheme(theme);
            ViewBag.CommonFile = GetCommonFile(theme);
        }

        private Theme GetThemeModel(string name)
        {
            var model = demoCacheManager.SassThemes
                .SelectMany(t => t.Swatches)
                .Concat(demoCacheManager.LessThemes)
                .FirstOrDefault(t => t.Name.Equals(name));

            if (model == null)
            {
                model = demoCacheManager.SassThemes.SelectMany(t => t.Swatches)
                    .First(s => s.Name.Equals("default-ocean-blue"));
            }

            return model;
        }

        private bool IsSassTheme(string name)
        {
            return demoCacheManager.SassThemes
               .SelectMany(t => t.Swatches)
               .Any(t => t.Name.Equals(name));
        }

        private string GetCommonFile(string theme)
        {
            var lessModel = demoCacheManager.LessThemes.FirstOrDefault(t => t.Name == theme);

            return lessModel != null ? lessModel.Common : "common-empty";
        }

        protected void LoadNavigation()
        {
            ViewBag.Navigation = demoCacheManager.NavigationWidgets;
        }

        protected void LoadCategories()
        {
            ViewBag.WidgetCategories = demoCacheManager.NavigationWidgets.GroupBy(w => w.Category).ToList();
        }

        protected IEnumerable<NavigationWidget> LoadWidgets()
        {
            var navJson = IOFile.ReadAllText(Controller.Server.MapPath("~/content/nav.json"));

            return JsonConvert.DeserializeObject<NavigationWidget[]>(navJson.Replace("$FRAMEWORK", "ASP.NET MVC"));
        }

        protected void UpdateHeader(string Url)
        {
            ResetHeader = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string ProductName = "asp-net-mvc";
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/nav-" + ProductName + "-csa-abs-component.html";

                try
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Header = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public void UpdateBanner(string Url)
        {
            if (Url.IndexOf("localhost") == -1)
            {
                string ProductName = "aspnet-mvc";
                string urlAddress = "https://www.telerik.com/webapi/announcements/getMarkup?url=https://demos.telerik.com/" + ProductName;

                try
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Banner = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        protected void UpdateFooter(string Url)
        {
            ResetFooter = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/footer-big-abs-markup.html";

                try
                {
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Footer = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void SetFeedbackId()
        {
            ViewBag.FeedbackId = "17DDhsKyPUgO6GlvL8WEfCCN6tikyInp4qpRGCvvs794";
        }
    }
}
