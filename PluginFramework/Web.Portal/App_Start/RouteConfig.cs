using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                  name: "Admin",
                  url: "admin",
                  defaults: new { controller = "Admin", action = "Index" }
             );

            routes.MapRoute(
                  name: "Module",
                  url: "admin/{module}/{action}/{id}",
                  defaults: new { controller = "Admin", action = "Index", module = UrlParameter.Optional, id = UrlParameter.Optional }
             );

            routes.MapRoute(
                name: "Site",
                url: "{parameters}",
                defaults: new { controller = "Home", action = "Index", parameters = UrlParameter.Optional }
            );
        }
    }
}
