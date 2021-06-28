using MiniAzureDevops.ItemTable.Application.Responses;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommandResponse : BaseResponse
    {
        public StoryDto Story { get; set; }
    }
}
