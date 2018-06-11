using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using DDD.EntityFramework;
using DDD.Services;

namespace DDD.Web
{
    public static class ContainerConfig
    {
        public static IContainer Create()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterTypes(builder);
            return builder.Build();
        }

        private static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();
            builder.RegisterModule<ServicesModule>();
        }
    }
}