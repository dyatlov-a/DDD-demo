using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace DDD.Domain.IssueAggregate.Specifications
{
    public class IssueDeadlineSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return e => e.Deadline < DateTime.UtcNow;
        }
    }
}
