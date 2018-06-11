using DDD.Domain.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DDD.Domain.Interfaces;
using LinqSpecs;

namespace DDD.EntityFramework.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _context = context;
        }

        public IEnumerable<Employee> GetAll(Specification<Employee> specification = null)
        {
            var query = _context.Set<Employee>().AsQueryable();

            if (specification != null)
            {
                query = query.Where(specification);
            }

            return query.ToList();
        }

        public Employee GetById(Guid id)
        {
            return _context.Set<Employee>().Single(o => o.Id == id);
        }

        public void Insert(Employee employee)
        {
            _context.Set<Employee>().Add(employee);
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
        }
    }
}
