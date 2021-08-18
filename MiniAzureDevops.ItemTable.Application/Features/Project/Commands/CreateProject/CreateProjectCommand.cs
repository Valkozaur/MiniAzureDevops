using MediatR;
using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<CreateProjectDto>, IMapTo<Domain.Entities.Project>
    {
        public string Name { get; set; }
    }
}
