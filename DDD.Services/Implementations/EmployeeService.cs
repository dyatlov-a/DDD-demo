using System;
using System.Collections.Generic;
using DDD.Domain.PersonAggregate;
using DDD.Domain.Interfaces;
using DDD.Domain.PersonAggregate.Specifications;
using DDD.Services.Contracts;
using DDD.Services.Dtos;

namespace DDD.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProjectionBuilder _projectionBuilder;

        public EmployeeService(IUnitOfWork unitOfWork, 
            IEmployeeRepository employeeRepository,
            IProjectionBuilder projectionBuilder)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (employeeRepository == null)
                throw new ArgumentNullException(nameof(employeeRepository));
            if (projectionBuilder == null)
                throw new ArgumentNullException(nameof(projectionBuilder));

            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _projectionBuilder = projectionBuilder;
        }

        public IEnumerable<EmployeeDto> GetHeads()
        {
            var employees = _employeeRepository.GetAll(new EmployeeHeadSpecification(isOnlyHead: true));
            var results = _projectionBuilder.Build<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
            return results;
        }

        public EmployeeDto GetById(Guid employeeId)
        {
            var employee = _employeeRepository.GetById(employeeId);
            var result = _projectionBuilder.Build<Employee, EmployeeDto>(employee);
            return result;
        }

        public Guid Create(EmployeeCreateDto employeeCreateDto)
        {
            var employee = new Employee(employeeCreateDto.Name, employeeCreateDto.Position);
            _employeeRepository.Insert(employee);
            _unitOfWork.Save();

            return employee.Id;
        }

        public void AddEmployee(Guid headId, Guid employeeId)
        {
            var head = _employeeRepository.GetById(headId);
            var employee = _employeeRepository.GetById(employeeId);
            head.AddEmployee(employee);
            _employeeRepository.Update(head);
            _unitOfWork.Save();
        }

        public void ChangePosition(Guid employeeId, string position)
        {
            var employee = _employeeRepository.GetById(employeeId);
            employee.ChangePosition(position);
            _employeeRepository.Update(employee);
            _unitOfWork.Save();
        }
    }
}
