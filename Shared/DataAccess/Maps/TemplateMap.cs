using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess.Maps
{
    public class TemplateMap : ClassMap<Template>
    {
        public TemplateMap()
        {
            Id(_ => _.Id);

            Map(_ => _.Name);

            HasMany(_ => _.Diagnoses)
                .Cascade.All()
                .Inverse()
                ;
        }
    }
}
