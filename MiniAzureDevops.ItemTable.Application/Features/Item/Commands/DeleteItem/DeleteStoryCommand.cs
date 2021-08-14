using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.DeleteStory
{
    public class DeleteStoryCommand : IRequest
    {
        public int ItemId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
