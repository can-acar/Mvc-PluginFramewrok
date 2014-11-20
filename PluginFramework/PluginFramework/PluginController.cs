using System.Collections.Generic;
using System.Web.Mvc;
using Autofac;

namespace PluginFramework
{
    public class PluginController : Controller, IPluginController
    {

        public string ControllerName
        {
            get
            {
                return GetType().Name.Replace("Controller", string.Empty);
            }
        }

        public static T GetService<T>()
        {
            return DependencyResolver.Current.GetService<T>();
        }

        public static IEnumerable<T> GetServices<T>()
        {
            return DependencyResolver.Current.GetServices<T>();
        }

    }
}
