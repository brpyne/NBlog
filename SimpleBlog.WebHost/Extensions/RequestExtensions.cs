using System;
using System.Linq;
using System.Web.Routing;

namespace Fullback.WebHost.Extensions
{
    public static class RequestExtensions
    {
        public static bool IsCurrentRoute(this RequestContext context, String areaName,
                                          String controllerName, params String[] actionNames)
        {
            RouteData routeData = context.RouteData;
            var routeArea = routeData.DataTokens["area"] as String;
            bool current = false;

            if (((String.IsNullOrEmpty(routeArea) && String.IsNullOrEmpty(areaName)) ||
                 (routeArea == areaName)) &&
                ((String.IsNullOrEmpty(controllerName)) ||
                 (routeData.GetRequiredString("controller") == controllerName)) &&
                ((actionNames == null) ||
                 actionNames.Contains(routeData.GetRequiredString("action"))))
            {
                current = true;
            }

            return current;
        }
    }
}