using System;

namespace Shared.Domain
{
    public class DomainObject
    {
        public virtual Guid Id { get; private set; }
    }
}
