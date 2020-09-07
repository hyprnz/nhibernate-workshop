using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine.Domain
{
    public class Log
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Text { get; set; }
    }
}
