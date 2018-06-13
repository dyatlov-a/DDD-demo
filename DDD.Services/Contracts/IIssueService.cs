using System;
using System.Collections.Generic;
using DDD.Domain.EmployeeAggregate;
using DDD.Domain.IssueAggregate;
using DDD.Services.Dtos;

namespace DDD.Services.Contracts
{
    public interface IIssueService
    {
        IEnumerable<IssueDto> GetAll();
        IEnumerable<IssueDto> GetOverduetIssues();
        IssueDto GetById(Guid issueId);
        Guid Create(IssueCreateDto issueCreateDto, IUser currentUser);
        void AppointTo(Guid issueId, Guid newResponsibleId);
        void ChangeStatus(Guid issueId, IssueStatus status);
        void Escalation(Guid issueId);
        void Remove(Guid issueId);
    }
}
