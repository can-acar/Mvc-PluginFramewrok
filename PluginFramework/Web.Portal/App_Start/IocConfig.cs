using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;


namespace Web.Portal
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterFilterProvider();
            //builder.RegisterModule(new IocModule());


            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}