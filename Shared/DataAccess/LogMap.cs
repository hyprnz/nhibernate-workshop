using FluentNHibernate.Mapping;
using Shared.Domain;

namespace Shared.DataAccess
{
    public class LogMap : ClassMap<Log>
    {
        public LogMap()
        {
            Id(x => x.Id);
            Map(x => x.Text);
        }
    }
}
