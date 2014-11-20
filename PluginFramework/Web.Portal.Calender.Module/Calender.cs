using System;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PluginFramework;
using PluginFramework.UI;
using PluginFramework.UI.Repositories.Interfaces;
using Web.Portal.Calender.Module.Controllers;

namespace Web.Portal.Calender.Module
{
    public class Calender : Plugin
    {
        protected override void Load(ContainerBuilder plugin)
        {
            plugin.RegisterType<Calender>().As<IPlugin>();

            //plugin.RegisterControllers(GetType().Assembly)
            //   .Named<IController>(GetControllerName);

            plugin.RegisterType<CalenderController>().Named<IController>(GetControllerName<CalenderController>());
            // plugin.RegisterControllers(GetType().Assembly)
            //.Named<IController>(GetControllerName);
        }

        protected override void AddMenu(NavigationBuilder builder)
        {
            builder.Add(new Menu
            {
                Guid = Guid.NewGuid(),
                MenuAction = "calender",
                MenuAccessLevel = 0,
                MenuIconUrl = "..",
                MenuName = "Calender"
            });
        }
    }
}
//            return RegistrationExtensions.Where<object, ScanningActivatorData, DynamicRegistrationStyle>(RegistrationExtensions.RegisterAssemblyTypes(builder, controllerAssemblies), (Func<Type, bool>) (t => ((bool) (typeof(IController).IsAssignableFrom(t) && t.get_Name().EndsWith("Controller", StringComparison.Ordinal)))));