using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.DeleteStory
{
    public class DeleteStoryCommand : IRequest
    {
        public ObjectId StoryId { get; set; }
    }
}
