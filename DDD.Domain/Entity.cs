using System;
using System.Collections.Generic;

namespace DDD.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }

        public byte[] RowVersion { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            var identity = obj as Entity;
            return identity != null && Id.Equals(identity.Id);
        }

        public override int GetHashCode()
        {
            return 2018858624 + EqualityComparer<Guid>.Default.GetHashCode(Id);
        }
    }
}
