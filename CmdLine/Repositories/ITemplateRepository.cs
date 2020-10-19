using CmdLine.Domain;
using System;

namespace CmdLine.Repositories
{
    public interface ITemplateRepository
    {
        Template GetById(Guid id);
        Guid Save(Template template);
    }
}
