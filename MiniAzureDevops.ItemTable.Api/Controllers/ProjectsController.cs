using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject;
using MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById;
using MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTablesByProjectId;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ProjectsController : BaseController
    {
        public ProjectsController(IMediator mediator) : base(mediator) { }

        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProjectById([FromRoute] GetProjectByIdQuery request)
            => this.Ok(await this.mediator.Send(request));

        [HttpGet("{projectId}/tables")]
        public async Task<IActionResult> GetTablesByProjectId([FromRoute] GetTablesByProjectIdQuery request)
            => this.Ok(await this.mediator.Send(request));

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] CreateProjectCommand request)
            => this.Created("", await this.mediator.Send(request));
    }
}
