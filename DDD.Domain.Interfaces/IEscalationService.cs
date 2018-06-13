using DDD.Domain.EmployeeAggregate;
using DDD.Domain.IssueAggregate;

namespace DDD.Domain.Interfaces
{
    public interface IEscalationService
    {
        void Escalation(Issue issue, Employee responsible);
    }
}
