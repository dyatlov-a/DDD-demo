using DDD.Domain.EmployeeAggregate;
using DDD.Domain.IssueAggregate;
using DDD.Domain.Interfaces;

namespace DDD.Services.Implementations
{
    public class EscalationService : IEscalationService
    {
        public void Escalation(Issue issue, Employee responsible)
        {
            if (issue.IsNeedEscalation())
            {
                var newResponsible = responsible.EscalationTo();
                issue.AppointTo(newResponsible);
            }
        }
    }
}
