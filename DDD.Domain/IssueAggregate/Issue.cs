using System;
using DDD.Domain.IssueAggregate.Specifications;
using DDD.Domain.PersonAggregate;

namespace DDD.Domain.IssueAggregate
{
    public class Issue : Entity
    {
        public string About { get; private set; }
        public InitiatorInfo Initiator { get; private set; }
        public Guid ResponsibleId { get; private set; }
        public IssueStatus Status { get; private set; }
        public IssueUrgency Urgency { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Deadline { get; private set; }
        

        protected Issue() { }

        public Issue(string about,
            IssueUrgency urgency,
            IUser initiator, 
            Employee responsible)
            : this()
        {
            if (String.IsNullOrWhiteSpace(about))
                throw new ArgumentException(nameof(about));
            if (initiator == null)
                throw new ArgumentNullException(nameof(initiator));
            if (responsible == null)
                throw new ArgumentNullException(nameof(responsible));

            About = about;
            Urgency = urgency;
            Initiator = new InitiatorInfo(initiator.Name, initiator.Position);
            ChangeStatus(IssueStatus.New);
            AppointTo(responsible);
            Created = DateTime.UtcNow;
            DeadlineUpdate();
        }

        private void DeadlineUpdate()
        {
            Deadline = DateTime.UtcNow.AddDays((int)Urgency);
        }

        private bool IsReadonly()
        {
            return new IssueReadonlySpecification().ToExpression().Compile()(this);
        }

        public bool IsNeedEscalation()
        {
            return !IsReadonly() && new IssueDeadlineSpecification().ToExpression().Compile()(this);
        }

        public void AppointTo(Employee newResponsible)
        {
            if (newResponsible == null || ResponsibleId == newResponsible.Id)
                return;

            ResponsibleId = newResponsible.Id;
            DeadlineUpdate();
        }

        public void ChangeStatus(IssueStatus status)
        {
            if (!IsReadonly())
                Status = status;
        }
    }
}
