using DDD.Domain.IssueAggregate;
using DDD.Domain.PersonAggregate;

namespace DDD.Domain.Interfaces
{
    public interface IEscalationService
    {
        void Escalation(Issue issue, Employee responsible);
    }
}
