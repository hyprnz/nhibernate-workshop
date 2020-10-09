using CmdLine.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine.DataAccess
{
    public class TemplateMap : ClassMap<Template>
    {
        public TemplateMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
        }
    }
}
