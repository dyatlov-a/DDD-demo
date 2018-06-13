using System;
using System.Collections.Generic;

namespace DDD.Domain.EmployeeAggregate
{
    public class Employee : Entity, IUser
    {
        public string Name { get; private set; }
        public string Position { get; private set; }

        public Guid? HeadId { get; private set; }
        public virtual Employee Head { get; private set; }
        public virtual ICollection<Employee> Employees { get; private set; }

        protected Employee()
        {
            Employees = new HashSet<Employee>();
        }

        public Employee(string name, string position)
            : this()
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException(nameof(name));
            if (String.IsNullOrWhiteSpace(position))
                throw new ArgumentException(nameof(position));

            Name = name;
            ChangePosition(position);
        }

        public void AddEmployee(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (Employees.Contains(employee))
                return;

            Employees.Add(employee);
        }

        public void ChangePosition(string position)
        {
            if (String.IsNullOrWhiteSpace(position))
                throw new ArgumentException(nameof(position));

            Position = position;
        }

        public Employee EscalationTo()
        {
            return Head;
        }
    }
}
