using System;
using System.Collections.Generic;
using DDD.Domain.IssueAggregate;
using DDD.Domain.PersonAggregate;
using DDD.Domain.Interfaces;
using DDD.Services.Contracts;
using DDD.Services.Dtos;

namespace DDD.Services.Implementations
{
    public class IssueService : IIssueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIssueRepository _issueRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEscalationService _escalationService;
        private readonly IProjectionBuilder _projectionBuilder;

        public IssueService(IUnitOfWork unitOfWork,
            IIssueRepository issueRepository, 
            IEmployeeRepository employeeRepository,
            IEscalationService escalationService,
            IProjectionBuilder projectionBuilder)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            if (issueRepository == null)
                throw new ArgumentNullException(nameof(issueRepository));
            if (employeeRepository == null)
                throw new ArgumentNullException(nameof(employeeRepository));
            if (escalationService == null)
                throw new ArgumentNullException(nameof(escalationService));
            if (projectionBuilder == null)
                throw new ArgumentNullException(nameof(projectionBuilder));

            _unitOfWork = unitOfWork;
            _issueRepository = issueRepository;
            _employeeRepository = employeeRepository;
            _escalationService = escalationService;
            _projectionBuilder = projectionBuilder;
        }

        public IEnumerable<IssueDto> GetAll()
        {
            var issues = _issueRepository.GetAll();
            var results = _projectionBuilder.Build<IEnumerable<Issue>, IEnumerable<IssueDto>>(issues);
            return results;
        }

        public IssueDto GetById(Guid issueId)
        {
            var issue = _issueRepository.GetById(issueId);
            var result = _projectionBuilder.Build<Issue, IssueDto>(issue);
            return result;
        }

        public Guid Create(IssueCreateDto issueCreateDto, IUser currentUser)
        {
            if (currentUser == null)
                throw new ArgumentNullException(nameof(currentUser));

            var responsible = _employeeRepository.GetById(issueCreateDto.ResponsibleId);
            var issue = new Issue(issueCreateDto.About, issueCreateDto.Urgency, currentUser, responsible);
            _issueRepository.Insert(issue);
            _unitOfWork.Save();

            return issue.Id;
        }

        public void AppointTo(Guid issueId, Guid newResponsibleId)
        {
            var issue = _issueRepository.GetById(issueId);
            var newResponsible = _employeeRepository.GetById(newResponsibleId);
            issue.AppointTo(newResponsible);
            _issueRepository.Update(issue);
            _unitOfWork.Save();
        }

        public void ChangeStatus(Guid issueId, IssueStatus status)
        {
            var issue = _issueRepository.GetById(issueId);
            issue.ChangeStatus(status);
            _unitOfWork.Save();
        }

        public void Escalation(Guid issueId)
        {
            var issue = _issueRepository.GetById(issueId);
            var responsible = _employeeRepository.GetById(issue.ResponsibleId);
            _escalationService.Escalation(issue, responsible);
            _issueRepository.Update(issue);
            _unitOfWork.Save();
        }

        public void Remove(Guid issueId)
        {
            _issueRepository.Remove(issueId);
            _unitOfWork.Save();
        }
    }
}
