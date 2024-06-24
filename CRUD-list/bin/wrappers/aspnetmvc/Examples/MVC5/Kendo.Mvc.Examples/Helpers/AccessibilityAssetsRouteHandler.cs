using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Kendo.Mvc.Examples
{
    public class AccessibilityAssetsRouteHandler : MvcRouteHandler
    {
        private bool IsAsset(string path)
        {
            return File.Exists(path);
        }
        protected override IHttpHandler GetHttpHandler(System.Web.Routing.RequestContext requestContext)
        {
            var path = requestContext.RouteData.Values["path"];

            if (path == null)
            {
                requestContext.RouteData.Values["action"] = "Index";
            }
            else if (IsAsset(requestContext.HttpContext.Server.MapPath("~/Content/accessibility-assets/" + path.ToString())))
            {
                requestContext.RouteData.Values["action"] = "Asset";
                requestContext.RouteData.Values["path"] = path.ToString();
            }
            else
            {
                requestContext.RouteData.Values["action"] = "Example";
                requestContext.RouteData.Values["widget"] = path.ToString();
            }

            return base.GetHttpHandler(requestContext);
        }
    }
}