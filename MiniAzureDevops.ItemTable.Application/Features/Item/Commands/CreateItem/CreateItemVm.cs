using MiniAzureDevops.ItemTable.Application.Mapping;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemVm : IMapFrom<Domain.Entities.Item>
    {
        public Guid Id { get; set; }

        public Guid ColumnId { get; set; }

        public string Name { get; set; }
        
    }
}