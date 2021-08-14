using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<CreateProjectDto>
    {
        public string Name { get; set; }
    }
}
