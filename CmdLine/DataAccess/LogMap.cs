using CmdLine.Domain;
using FluentNHibernate.Mapping;

namespace CmdLine.DataAccess
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
