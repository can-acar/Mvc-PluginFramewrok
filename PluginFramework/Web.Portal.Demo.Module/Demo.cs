using System;
using System.Web.Mvc;
using Autofac;
using PluginFramework;
using PluginFramework.UI;
using Web.Portal.Demo.Module.Controllers;

namespace Web.Portal.Demo.Module
{
    public class Demo : Plugin
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<Demo>().As<IPlugin>();
            //builder.RegisterType<MenuRepository>().As<IMenuRepository>();

            //builder.RegisterControllers(GetType().Assembly)
            //   .Named<IController>(GetControllerName);

            //builder.RegisterControllers(GetType().Assembly)
            //   .Named<IController>(GetControllerName<AdminController>());
            builder.RegisterType<HomeController>().Named<IController>(GetControllerName<HomeController>());
            builder.RegisterType<DemoController>().Named<IController>(GetControllerName<DemoController>());
            builder.RegisterType<AdminController>().Named<IController>(GetControllerName<AdminController>());
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
