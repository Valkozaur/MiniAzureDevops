namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemDto
    {
        public Guid Id { get; set; }

        public Guid ColumnId { get; set; }

        public string Name { get; set; }
        
    }
}