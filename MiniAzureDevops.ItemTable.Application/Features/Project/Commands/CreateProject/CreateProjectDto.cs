using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectDto : IMapFrom<Domain.Entities.Project>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}