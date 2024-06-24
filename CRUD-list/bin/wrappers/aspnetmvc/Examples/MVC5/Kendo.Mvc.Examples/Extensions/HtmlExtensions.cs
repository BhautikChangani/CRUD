using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using Kendo.Models;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using Kendo.Mvc.Examples.Models;
using System.Reflection;

namespace Kendo.Extensions
{
    public static class HtmlExtensions
    {
        public static IHtmlString ExampleLink(this HtmlHelper html, NavigationExample example)
        {
            var href = html.ExampleUrl(example);

            var className = "kd-link";

            if (example.New)
            {
                className += " new-example";
            }

            if (example.Updated)
            {
                className += " updated-example";
            }

            var routeData = html.ViewContext.RouteData;
            var currentAction = routeData.Values["action"].ToString().ToLower().Replace("_", "-");
            var currentController = routeData.Values["controller"].ToString().ToLower().Replace("_", "-");

            if (href.EndsWith(currentController + "/" + currentAction))
            {
                className += " active";
            }

            StringBuilder link = new StringBuilder();

            link.Append("<a ");

            if (!String.IsNullOrEmpty(className))
            {
                link.Append("class=\"" + className + "\" ");
            }

            link.Append("href=\"" + href + "\">");

            link.Append(example.Text);

            if (example.New)
            {
                link.Append("<span class=\"tag tag-new new-widget\">New</span>");
            }

            if (example.Updated)
            {
                link.Append("<span class=\"tag tag-updated updated-widget\">Updated</span>");
            }

            link.Append("</a>");

            return html.Raw(link.ToString());
        }

        public static IHtmlString GroupExpander(this HtmlHelper html, NavigationExampleGroup group)
        {
            StringBuilder link = new StringBuilder();

            link.AppendLine("<a class=\"kd-link kd-group-link kd-link-bolded\" href=\"#\">");
            link.AppendLine("<span class=\"k-icon k-font-icon k-i-arrow-chevron-down\"></span>");
            link.AppendLine(group.Name);
            link.AppendLine("</a>");

            return html.Raw(link.ToString());
        }

        public static IHtmlString WidgetExpander(this HtmlHelper html, NavigationWidget widget, bool current)
        {
            var text = widget.Text;

            StringBuilder link = new StringBuilder();
            var chevron = current ? "right" : "down";

            link.AppendLine(!current ? "<a class=\"kd-link kd-group-link kd-link-bolded\" href=\"#\">" : "<a class=\"kd-link kd-group-link\" href=\"#\">");
            link.AppendFormat("<span class=\" k-font-icon k-i-arrow-chevron-{0}\"></span>", chevron);
            link.AppendLine(text);

            if (widget.Beta)
            {
                link.Append(String.Format("<span class=\"tag tag-bet beta-widget\">{0}</span>", "Beta"));
            }

            if (widget.New)
            {
                link.Append(String.Format("<span class=\"tag tag-new new-widget\">{0}</span>", "New"));
            }

            if (widget.Updated)
            {
                link.Append(String.Format("<span class=\"tag tag-updated updated-widget\">{0}</span>", "Updated"));
            }

            link.Append("</a>");

            return html.Raw(link.ToString());
        }

        public static string ExampleUrl(this HtmlHelper html, NavigationExample example)
        {
            var sectionAndExample = example.Url.Split('/');

            return new UrlHelper(html.ViewContext.RequestContext).ExampleUrl(sectionAndExample[0], sectionAndExample[1]);
        }

        public static string ExampleUrl(this HtmlHelper html, NavigationExample example, string product)
        {
            var sectionAndExample = example.Url.Split('/');

            var url = string.Join("/", LiveSamplesRoot, product, sectionAndExample[0], sectionAndExample[1]);

            return url;
        }

        public static string ProductExampleUrl(this HtmlHelper html, NavigationExample example, string product)
        {
            var sectionAndExample = example.Url.Split('/');

            var url = string.Join("/", LiveSamplesRoot, product, sectionAndExample[0]);

            return url;
        }

        public static string LiveSamplesRoot
        {
            get
            {
                return "https://demos.telerik.com";
            }
        }

        public static IHtmlString WidgetLink(this HtmlHelper html, NavigationWidget widget, string product, bool noText = false)
        {
            var viewBag = html.ViewContext.Controller.ViewBag;

            var href = html.ExampleUrl(widget.Items[0]);

            var text = widget.Text;

            StringBuilder link = new StringBuilder();

            link.AppendFormat("<a class=\"kd-link\" href=\"{0}\">", href);
            link.AppendFormat("<span class=\"link-text\">{0}</span>", text);

            if (widget.Beta)
            {
                link.Append(String.Format("<span class=\"tag tag-bet beta-widget\">{0}</span>", noText ? "" : "Beta"));
            }

            if (widget.New)
            {
                link.Append(String.Format("<span class=\"tag tag-new new-widget\">{0}</span>", noText ? "" : "New"));
            }

            if (widget.Updated)
            {
                link.Append(String.Format("<span class=\"tag tag-updated updated-widget\">{0}</span>", noText ? "" : "Updated"));
            }

            link.Append("</a>");

            return html.Raw(link.ToString());
        }

        public static string StyleRel(this HtmlHelper html, string styleName)
        {
            if (styleName.ToLowerInvariant().EndsWith("less"))
            {
                return "stylesheet/less";
            }

            return "stylesheet";
        }

        public static IHtmlString StyleLink(this HtmlHelper html, string styleName) {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Style(styleName);
            return html.Raw("<link data-href=\"" + url + "\" rel=\"" + html.StyleRel(styleName) + "\" />");
        }

        public static IHtmlString StyleLink(this HtmlHelper html, string styleName, string theme) {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Style(styleName, theme);
            return html.Raw("<link href=\"" + url + "\" rel=\"" + html.StyleRel(styleName) + "\" />");
        }

        public static String Version(this HtmlHelper html)
        {
#if DEBUG
            return "?v=" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
#else
            return  "?v=" + ConfigurationManager.AppSettings["VERSION"];
#endif
        }
    }
}
