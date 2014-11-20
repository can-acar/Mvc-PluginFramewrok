using System.Linq.Expressions;
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
                  url: "admin/{controller}/{action}/{id}",
                  defaults: new
                  {
                      controller = "Admin",
                      action = "Index",
                      area = "admin",
                      id = UrlParameter.Optional
                  }

             );

            routes.MapRoute(
                name: "Site",
                url: "{parameters}",
                defaults: new { controller = "Home", action = "Index", parameters = UrlParameter.Optional }
            );

            //var route = new Route("Admin", new RouteValueDictionary {
            //    {"area","Dashboard"},
            //    {"controller","admin"},
            //    {"action","index"}
            //}, new MvcRouteHandler());

            //routes.Add(route);
        }
    }
}
