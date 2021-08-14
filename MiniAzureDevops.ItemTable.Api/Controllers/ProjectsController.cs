using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController(IMediator mediator) : base(mediator) {}

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] CreateProjectCommand createProjectCommand)
            => this.Created("", await this.mediator.Send(createProjectCommand));
    }
}
