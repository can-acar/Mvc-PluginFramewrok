using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;


namespace PluginFramework
{
    public class PluginControllerFactory : DefaultControllerFactory
    {
        private readonly IContainer _container;
        public PluginControllerFactory(IContainer container)
        {
            _container = container;
        }

        protected override Type GetControllerType(RequestContext request_context, string controller_name)
        {
            var controller = base.GetControllerType(request_context, controller_name);
            if (controller != null) return controller;
            var routes = RouteTable.Routes;
            object pluginController;
            //var pluginController = _container.Resolve<IEnumerable<IController>>()
            //                                 .ToList()
            //                                 .OfType<IPluginController>()
            //                                 .FirstOrDefault(c => c.ControllerName == controller_name);
            //var pluginController = _container.Resolve<IController>();

            if (_container.TryResolveNamed(controller_name, typeof(IController), out pluginController))
            {
                return pluginController.GetType();

            }
            return null;
            // return (pluginController != null) ? pluginController.GetType() : null;
        }

        public override void ReleaseController(IController controller)
        {

            var disposable = controller as IDisposable;

            if (disposable != null)
            {

                disposable.Dispose();

            }

        }

    }
}
