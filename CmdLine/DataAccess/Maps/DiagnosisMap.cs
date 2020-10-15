using CmdLine.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CmdLine.DataAccess.Maps
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
