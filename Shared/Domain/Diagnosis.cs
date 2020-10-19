namespace Shared.Domain
{
    public class Diagnosis : DomainObject
    {
        public virtual string Name { get; set; }

        public virtual Template Template { get; set; }
    }
}
