using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess.Maps
{
    public class DiagnosisMap : ClassMap<Diagnosis>
    {
        public DiagnosisMap()
        {
            Id(_ => _.Id);

            Map(_ => _.Name);

            References(_ => _.Template);
        }
    }
}
