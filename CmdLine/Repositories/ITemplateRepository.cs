using CmdLine.Domain;
using NHibernate;
using System;

namespace CmdLine.Repositories
{
    public interface IHaveSession
    {
        ISession Session { get; set; }
    }
    public interface ITemplateRepository : IHaveSession
    {
        Template GetById(Guid id);
        Guid Save(Template template);
    }
}
