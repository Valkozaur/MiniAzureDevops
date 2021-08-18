using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdDto : IMapFrom<Domain.Entities.Project>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
