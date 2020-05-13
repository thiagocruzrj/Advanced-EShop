using System;

namespace AES.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
    }
}
