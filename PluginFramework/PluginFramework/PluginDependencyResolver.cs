using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Autofac;

namespace PluginFramework
{
    public class PluginDependencyResolver : IDependencyResolver
    {

        private readonly IContainer _container;

        public PluginDependencyResolver(IContainer container)
        {

            _container = container;
        }

        public object GetService(Type service_type)
        {

            return _container.IsRegistered(service_type)
                    ? _container.Resolve(service_type)
                    : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {

            var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);

            var instance = _container.Resolve(enumerableServiceType);

            return ((IEnumerable)instance).Cast<object>();
        }
    }
}