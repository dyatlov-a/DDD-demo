using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace DDD.Domain.EmployeeAggregate.Specifications
{
    public class EmployeeHeadSpecification : Specification<Employee>
    {
        public bool IsOnlyHead { get; private set; }

        public EmployeeHeadSpecification(bool isOnlyHead)
        {
            IsOnlyHead = isOnlyHead;
        }

        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => !IsOnlyHead || e.Head == null;
        }
    }
}
