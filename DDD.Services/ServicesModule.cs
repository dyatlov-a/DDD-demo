using Autofac;
using DDD.Domain.Interfaces;
using DDD.Services.Contracts;
using DDD.Services.Implementations;

namespace DDD.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EscalationService>().As<IEscalationService>().InstancePerRequest();
            builder.RegisterType<IssueService>().As<IIssueService>().InstancePerRequest();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();
            builder.RegisterType<ProjectionBuilder>().As<IProjectionBuilder>().SingleInstance();

            base.Load(builder);
        }
    }
}
