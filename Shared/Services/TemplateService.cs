using Shared.Domain;
using Shared.Repositories;
using System;

namespace Shared.Services
{
    public class TemplateService : ITemplateService
    {
        public TemplateService(ITemplateRepository templateRepository)
        {
            TemplateRepository = templateRepository;
        }

        public Template Create()
        {
            var template = new Template() { Name = $"Template {DateTime.Now.Ticks}" };
            var diagnosis1 = new Diagnosis() { Name = "Diagnosis1", Template = template };
            template.Diagnoses.Add(diagnosis1);
            var objectId = TemplateRepository.Save(template);
            return TemplateRepository.GetById(objectId);
        }

        private ITemplateRepository TemplateRepository { get; }
    }
}
