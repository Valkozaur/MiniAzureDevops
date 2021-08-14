using MediatR;
using MiniAzureDevops.ItemTable.Domain.Entities.Enumerations;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommand : IRequest<CreateItemDto>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ItemType Type { get; set; }

        public Guid ColumnId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
