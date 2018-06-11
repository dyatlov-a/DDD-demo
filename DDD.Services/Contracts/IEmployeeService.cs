using System;
using System.Collections.Generic;
using DDD.Services.Dtos;

namespace DDD.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetHeads();
        EmployeeDto GetById(Guid employeeId);
        Guid Create(EmployeeCreateDto employeeCreateDto);
        void AddEmployee(Guid headId, Guid employeeId);
        void ChangePosition(Guid employeeId, string position);
    }
}
