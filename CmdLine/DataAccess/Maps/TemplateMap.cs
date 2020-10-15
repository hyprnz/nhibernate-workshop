using CmdLine.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace CmdLine.DataAccess.Maps
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
