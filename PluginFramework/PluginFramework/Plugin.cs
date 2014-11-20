using System;
using System.Reflection;
using System.Web.Routing;



namespace PluginFramework
{
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
            PluginAssembly = Assembly.GetAssembly(GetType());
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

        public virtual void RegisterRoutes(RouteCollection route_collection)
        {

        }

        public virtual void Install(ContainerBuilder builder)
        {

        }
        public virtual void Install(IContainer builder)
        {

        }

        public override string ToString()
        {
            return string.Format("{0}", PluginName);
        }

    }
}
