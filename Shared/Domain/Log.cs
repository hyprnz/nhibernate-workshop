using System;

namespace Shared.Domain
{
    public class Log
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Text { get; set; }
    }
}
