using CmdLine.Domain;
using NHibernate;
using System;

namespace CmdLine.Repositories
{
    public interface INeedSession
    {
        ISession Session { get; set; }
    }
    public interface ITemplateRepository : INeedSession
    {
        Template GetById(Guid id);
        Guid Save(Template template);
    }
}
