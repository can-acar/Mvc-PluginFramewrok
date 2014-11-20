using Autofac;


namespace Web.Portal
{
    public class IocModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterType<MenuRepository>().As<IMenuRepository>();
           // builder.RegisterType<AdminController>().As<IController>();
           // builder.RegisterType<MenuRepository>().As<IMenuRepository>().InstancePerRequest();
            base.Load(builder);
        }
    }
}