using CmdLine.DataAccess;
using Shared.Domain;
using System;

namespace Shared.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        public TemplateRepository(ISessionAccessor sessionAccessor)
        {
            SessionAccessor = sessionAccessor;
        }

        public Guid Save(Template template)
        {
            return SessionAccessor.Save(template);
        }

        public Template GetById(Guid id)
        {
            return SessionAccessor.Get<Template>(id);
        }

        private ISessionAccessor SessionAccessor { get; }
    }
}
