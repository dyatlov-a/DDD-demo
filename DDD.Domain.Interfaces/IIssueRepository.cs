using System;
using System.Collections.Generic;
using DDD.Domain.IssueAggregate;
using LinqSpecs;

namespace DDD.Domain.Interfaces
{
    public interface IIssueRepository
    {
        IEnumerable<Issue> GetAll(Specification<Issue> specification = null);
        Issue GetById(Guid id);
        void Insert(Issue objective);
        void Update(Issue objective);
        void Remove(Guid id);
    }
}
