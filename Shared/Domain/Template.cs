using System.Collections.Generic;

namespace Shared.Domain
{
    public class Template : DomainObject
    {
        public virtual string Name { get; set; }
        public virtual IList<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();
    }
}
