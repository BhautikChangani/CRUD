using Kendo.Mvc.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace Kendo.Mvc.Examples
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //register Reporting services routs prior to default routes to prevent greedy route in the routes configuration and 405 errors:
            //https://docs.telerik.com/reporting/knowledge-base/html5-report-viewer-throws-405-method-not-allowed-error

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionRouteHandler();

        }
    }
}
