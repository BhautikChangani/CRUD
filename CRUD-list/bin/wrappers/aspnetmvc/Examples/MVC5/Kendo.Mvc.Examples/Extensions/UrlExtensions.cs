using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.Hosting;

namespace Kendo.Extensions
{
    public static class UrlExtensions
    {
        public static string Widget(this UrlHelper url, string widget)
        {
            return url.ExampleUrl(widget, "index");
        }

        public static string ExampleUrl(this UrlHelper url, string widget, string example)
        {
            var widgetUrl = url.Action(example, widget);

            if (example == "index" && !widgetUrl.EndsWith("index"))
            {
                widgetUrl += "/index";
            }

            return widgetUrl;
        }

        public static string Script(this UrlHelper url, string file)
        {
            return ResourceUrl(url, "js", file, IsAbsoluteUrl(file));
        }

        public static string Style(this UrlHelper url, string file, string theme)
        {
            return url.Style(file.Replace("CURRENT_THEME", theme));
        }

        public static string Style(this UrlHelper url, string file)
        {
            return ResourceUrl(url, "styles", file, IsAbsoluteUrl(file));
        }

        private static string ResourceUrl(UrlHelper url, string assetType, string file, bool isAbsoluteUrl)
        {
            var CDN_ROOT = ConfigurationManager.AppSettings["CDN_ROOT"];
            var themesCdn = ConfigurationManager.AppSettings["THEMES_CDN"];
            var themesVersion = ConfigurationManager.AppSettings["THEMES_VERSION"];

            if (CDN_ROOT == "$CDN_ROOT" && assetType == "js")
            {
                return url.Content(string.Format("~/Scripts/{0}", file));
            }

            if (CDN_ROOT == "$THEMES_VERSION" && assetType == "styles")
            {
                return url.Content(string.Format("~/content/web/{0}", file));
            }

            if (isAbsoluteUrl == true)
            {
                return file;
            }

            if (assetType == "styles")
            {
                var stylesFolder = file.Split('-').First();

                return url.Content(string.Format("{0}/{1}/{2}/{3}",
                    themesCdn,
                    themesVersion,
                    stylesFolder,
                    file
                ));
            }

            return url.Content(string.Format("{0}/{1}/{2}", CDN_ROOT, assetType, file));
        }

        public static bool IsAbsoluteUrl(string url)
        {
            Uri result;
            return Uri.TryCreate(url, UriKind.Absolute, out result);
        }
    }
}
