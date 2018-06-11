using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DDD.Domain.IssueAggregate;
using DDD.Domain.Interfaces;
using LinqSpecs;

namespace DDD.EntityFramework.Implementations
{
    public class IssueRepository : IIssueRepository
    {
        private readonly AppDbContext _context;

        public IssueRepository(AppDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<Issue> GetAll(Specification<Issue> specification = null)
        {
            var query = _context.Set<Issue>().AsQueryable();

            if (specification != null)
            {
                query = query.Where(specification);
            }

            return query.ToList();
        }

        public Issue GetById(Guid id)
        {
            return _context.Set<Issue>().Single(o => o.Id == id);
        }

        public void Insert(Issue objective)
        {
            _context.Set<Issue>().Add(objective);
        }

        public void Update(Issue objective)
        {
            _context.Entry(objective).State = EntityState.Modified;
        }

        public void Remove(Guid id)
        {
            var objective = GetById(id);
            _context.Entry(objective).State = EntityState.Deleted;
        }
    }
}
