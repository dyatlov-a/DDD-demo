using System;
using System.ComponentModel.DataAnnotations;
using DDD.Domain.IssueAggregate;

namespace DDD.Services.Dtos
{
    public class IssueCreateDto
    {
        [Required]
        public string About { get; set; }
        public IssueUrgency Urgency { get; set; }
        public Guid ResponsibleId { get; set; }
    }
}
