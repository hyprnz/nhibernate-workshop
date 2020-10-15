using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine.Domain
{
    public class Diagnosis
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }

        public virtual Template Template { get; set; }
    }
}
