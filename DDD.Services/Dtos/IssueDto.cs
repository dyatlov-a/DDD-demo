using System;
using DDD.Domain.IssueAggregate;

namespace DDD.Services.Dtos
{
    public class IssueDto
    {
        public Guid Id { get; set; }
        public string About { get; set; }
        public InitiatorInfoDto Initiator { get; set; }
        public Guid ResponsibleId { get; set; }
        public IssueStatus Status { get; set; }
        public IssueUrgency Urgency { get; set; }
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
    }
}
