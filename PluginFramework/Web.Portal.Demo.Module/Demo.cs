using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PluginFramework;
using PluginFramework.UI.Repositories;
using PluginFramework.UI.Repositories.Interfaces;
using Web.Portal.Demo.Module.Controllers;

namespace Web.Portal.Demo.Module
{
    public class Demo : Plugin
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(
                     typeof(MvcApplication).Assembly
                 ).PropertiesAutowired();
            builder.RegisterType<Demo>().As<IPlugin>();
            builder.RegisterType<MenuRepository>().As<IMenuRepository>();

            //builder.RegisterType<HomeController>()
            //       .As<IController>()
            //       .Named<IController>(GetControllerName<HomeController>());

            //builder.RegisterType<AdminController>()
            //       .As<IController>().Named<IController>(GetControllerName<AdminController>());

            builder.RegisterControllers(GetType().Assembly)
                .Named<IController>(t => t.Name.Replace("Controller", string.Empty));
        }


    }
}
