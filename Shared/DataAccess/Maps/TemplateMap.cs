using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess.Maps
{
    public class TemplateMap : DomainObjectMap<Template>
    {
        public TemplateMap()
        {
            Map(_ => _.Name);

            HasMany(_ => _.Diagnoses)
                .Cascade.All()
                .Inverse()
                ;
        }
    }
}
