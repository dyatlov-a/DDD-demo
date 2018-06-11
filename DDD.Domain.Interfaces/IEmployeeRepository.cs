using System;
using System.Collections.Generic;
using DDD.Domain.PersonAggregate;
using LinqSpecs;

namespace DDD.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll(Specification<Employee> specification = null);
        Employee GetById(Guid id);
        void Insert(Employee employee);
        void Update(Employee employee);
    }
}
