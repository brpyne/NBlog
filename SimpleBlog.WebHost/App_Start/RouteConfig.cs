using System.Web.Mvc;
using System.Web.Routing;

namespace Fullback.WebHost
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("api/{*pathInfo}");
            routes.IgnoreRoute("swagger-ui/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );

            routes.MapRoute(
                "Error - 404",
                "NotFound",
                new {action = "Error"}
                );

            routes.MapRoute(
                "Error - 500",
                "ServerError",
                new {action = "Error"}
                );
        }
    }
}