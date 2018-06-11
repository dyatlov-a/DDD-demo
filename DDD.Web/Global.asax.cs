using System.Web.Http;
using Autofac.Integration.WebApi;
using DDD.Web.WebInfrastructure;

namespace DDD.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(ContainerConfig.Create());
            GlobalConfiguration.Configuration.Filters.Add(new ExceptionHandlerAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new ValidateModelAttribute());
            ProjectionConfig.Register();
        }
    }
}
