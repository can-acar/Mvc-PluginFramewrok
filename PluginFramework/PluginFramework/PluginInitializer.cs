﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;


namespace PluginFramework
{

    public class PluginInitializer
    {
        private const string PLUGINFOLDER = "Plugins";
        private const string DEFAULTMASTER = "Site";
        private const string DEFAULTRAZORMASTER = "_Layout";
        private static string PluginBasePath;

        public static void Initialize()
        {
            PluginBasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PLUGINFOLDER);

            var plugins = new List<IPlugin>();
            var builder = new ContainerBuilder();
            var assemblies = Directory.EnumerateFiles(PluginBasePath, "*.Module.dll", SearchOption.AllDirectories)
                                      .Select(Assembly.LoadFile)
                                      .ToArray();
         
            builder.RegisterControllers(assemblies);

            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyModules(assemblies);

            builder.RegisterModelBinderProvider();

            builder.RegisterFilterProvider();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            foreach (var plugin in container.Resolve<IEnumerable<IPlugin>>())
            {
                plugins.Add(plugin);
                plugin.RegisterRoutes(RouteTable.Routes);

            }

            ControllerBuilder.Current.SetControllerFactory(new PluginControllerFactory(container));

            var pluginWebFormViewEngine = new PluginFormViewEngine(PLUGINFOLDER, plugins, DEFAULTMASTER);
            var pluginViewEngine = new PluginViewEngine(PLUGINFOLDER, plugins, DEFAULTRAZORMASTER);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(pluginWebFormViewEngine);
            ViewEngines.Engines.Add(pluginViewEngine);
        }
    }
}
