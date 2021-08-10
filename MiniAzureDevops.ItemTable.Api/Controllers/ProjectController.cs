using MediatR;
using Microsoft.AspNetCore.Mvc;
using MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Api.Controllers
{
    public class ProjectController : BaseController
    {
        public ProjectController(IMediator mediator) : base(mediator) {}

        [HttpPost(Name = "AddProject")]
        public async Task<CreateProjectCommandResponse> AddProject([FromBody] CreateProjectCommand createProjectCommand)
            => await this.mediator.Send(createProjectCommand);
    }
}
