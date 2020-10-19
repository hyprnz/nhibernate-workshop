using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess.Maps
{
    public class DomainObjectMap<T> : ClassMap<T> where T : DomainObject
    {
        protected DomainObjectMap()
        {
            Id(_ => _.Id);
        }
    }
}
