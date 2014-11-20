using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace PluginFramework
{
    public interface IPlugin
    {
        /// <summary>
        /// PluginName
        /// </summary>
        string PluginName { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="route_collection" type="RouteCollection"></param>
        void RegisterRoutes(RouteCollection route_collection);

        void Install(ContainerBuilder builder);
        void Install(IContainer container);
    }
}