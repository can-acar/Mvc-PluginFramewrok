namespace PluginFramework
{
    using System;
    using System.Reflection;
    using System.Web.Routing;
    using PluginFramework.UI;
    using Autofac;
    using Autofac.Integration.Mvc;
    using Module = Autofac.Module;
    public abstract class Plugin : Module, IPlugin
    {
        public Assembly PluginAssembly;
        public string MenuName { set; get; }

        protected Plugin()
        {
            PluginAssembly = GetType().Assembly;
        }

        protected override void Load(ContainerBuilder plugin)
        {
        }

        protected virtual void AddMenu(NavigationBuilder builder)
        {
        }

        public string GetControllerName<TController>()
        {
            return typeof(TController).Name.Replace("Controller", string.Empty);
        }

        public string GetControllerName(Type t)
        {
            return t.Name.Replace("Controller", string.Empty);
        }

        public virtual void RegisterRoutes(RouteCollection route_collection)
        {
        }

        public string AssemblyName
        {
            get
            {
                return PluginAssembly.GetName().Name;
            }
        }

        public string PluginName
        {
            get { return AssemblyName; }
        }

        public IPlugin IPlugin
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public override string ToString()
        {
            return string.Format("{0}", PluginName);
        }

    }
}
