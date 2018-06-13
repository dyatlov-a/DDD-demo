using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace DDD.Domain.IssueAggregate.Specifications
{
    public class IssueDeadlineSpecification : Specification<Issue>
    {
        public DateTime Deadline { get; private set; }

        public IssueDeadlineSpecification(DateTime deadline)
        {
            Deadline = deadline;
        }

        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return e => e.Deadline < Deadline;
        }
    }
}
