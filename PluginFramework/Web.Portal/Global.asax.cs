using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using PluginFramework;


namespace Web.Portal
{

    public class MvcApplication : HttpApplication
    {

        protected void Application_Start()
        {

            
            //IocConfig.RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            PluginInitializer.Initialize();
        }
    }
}
