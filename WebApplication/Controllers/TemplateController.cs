using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Shared.Domain;
using Shared.Repositories;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        public TemplateController(ITemplateRepository templateRepository)
        {
            TemplateRepository = templateRepository;
        }

        [HttpGet]
        public virtual string Get()
        {
            var retrieved = DoSomethingWithRepository();
            return $"Template {retrieved.Name} has {retrieved.Diagnoses.Count} diagnoses.";
        }

        private Template DoSomethingWithRepository()
        {
            var template = new Template() { Name = "Template42" };
            var diagnosis1 = new Diagnosis() { Name = "Diagnosis1", Template = template };
            template.Diagnoses.Add(diagnosis1);
            var objectId = TemplateRepository.Save(template);
            return TemplateRepository.GetById(objectId);
        }

        private ITemplateRepository TemplateRepository { get; }
    }
}
