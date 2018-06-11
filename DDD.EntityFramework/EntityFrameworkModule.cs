using Autofac;
using DDD.Domain.Interfaces;
using DDD.EntityFramework.Implementations;

namespace DDD.EntityFramework
{
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerRequest();
            builder.RegisterType<IssueRepository>().As<IIssueRepository>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
