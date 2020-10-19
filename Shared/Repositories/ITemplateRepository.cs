using Shared.Domain;
using System;

namespace Shared.Repositories
{
    public interface ITemplateRepository
    {
        Template GetById(Guid id);
        Guid Save(Template template);
    }
}
