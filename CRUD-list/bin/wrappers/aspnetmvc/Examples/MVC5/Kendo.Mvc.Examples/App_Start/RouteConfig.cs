using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kendo.Mvc.Examples
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.LowercaseUrls = true;
            routes.RouteExistingFiles = true;

            routes.MapRoute(
                "SearchRoute",
                "search",
                new { controller = "Home", action = "Search" }
            );

            routes.MapRoute(
                "SitemapRoute",
                "SitemapXml",
                new { controller = "Home", action = "SitemapXml" }
             );

            routes.Add("AccessibilityHandler", new Route(
                "accessibility/{*path}",
                new RouteValueDictionary { { "controller", "Accessibility" } },
                new AccessibilityAssetsRouteHandler()
            ));

            routes.Add("Default", new Route(
                "{controller}/{action}",
                new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } },
                new HyphenatedRouteHandler()
            ));
        }
    }
}