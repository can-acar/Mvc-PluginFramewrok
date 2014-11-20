using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;


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
            var routeValue = HttpContext.Current.Request.RequestContext.RouteData.Values;
            var controller = base.GetControllerType(request_context, controller_name);
            object pluginController;

            if (!routeValue.ContainsKey("module"))
                return _container.TryResolveNamed(controller_name.UcFirst(), typeof(IController), out pluginController)
                    ? pluginController.GetType()
                    : controller;
            var pluginName = (string)routeValue["module"];

            if (_container.TryResolveNamed(pluginName.UcFirst(), typeof(IController), out pluginController))
            {
                return pluginController.GetType();
            }

            return _container.TryResolveNamed(controller_name.UcFirst(), typeof(IController), out pluginController) ? pluginController.GetType() : controller;
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
