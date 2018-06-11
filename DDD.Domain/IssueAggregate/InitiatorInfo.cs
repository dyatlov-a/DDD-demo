using System;
using System.Collections.Generic;

namespace DDD.Domain.IssueAggregate
{
    public class InitiatorInfo : ValueObject
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

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Position;
        }
    }
}
