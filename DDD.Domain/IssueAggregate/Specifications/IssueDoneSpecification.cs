﻿using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace DDD.Domain.IssueAggregate.Specifications
{
    public class IssueDoneSpecification : Specification<Issue>
    {
        public override Expression<Func<Issue, bool>> ToExpression()
        {
            return e => e.Status == IssueStatus.Done;
        }
    }
}
