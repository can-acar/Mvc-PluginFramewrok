using System.Web.Routing;

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

    }
}