using System;

namespace DDD.Domain.IssueAggregate
{
    public class InitiatorInfo
    {
        public string Name { get; private set; }
        public string Position { get; private set; }

        protected InitiatorInfo() {}

        public InitiatorInfo(string name, string position)
            : this()
        {
            if (String.IsNullOrWhiteSpace(name))
                throw  new ArgumentException(nameof(name));
            if (String.IsNullOrWhiteSpace(position))
                throw new ArgumentException(nameof(position));

            Name = name;
            Position = position;
        }
    }
}
