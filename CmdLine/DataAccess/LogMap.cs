using CmdLine.Domain;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

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
