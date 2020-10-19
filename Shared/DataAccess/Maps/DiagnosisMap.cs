using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess.Maps
{
    public class DiagnosisMap : DomainObjectMap<Diagnosis>
    {
        public DiagnosisMap()
        {
            Map(_ => _.Name);

            References(_ => _.Template);
        }
    }
}
