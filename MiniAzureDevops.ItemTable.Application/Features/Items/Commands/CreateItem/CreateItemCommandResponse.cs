using MiniAzureDevops.ItemTable.Application.Responses;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommandResponse : BaseResponse
    {
        public ItemDto Item { get; set; }
    }
}
