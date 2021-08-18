using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetItemByIdVm : IMapFrom<Domain.Entities.Item>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}