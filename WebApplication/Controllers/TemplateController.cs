using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Shared.Services;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        public TemplateController(ITemplateService templateService)
        {
            TemplateService = templateService;
        }

        [HttpGet]
        public virtual string Get()
        {
            var retrieved = TemplateService.Create();
            return $"Template {retrieved.Name} has {retrieved.Diagnoses.Count} diagnoses.";
        }

        private ITemplateService TemplateService { get; }
    }
}
