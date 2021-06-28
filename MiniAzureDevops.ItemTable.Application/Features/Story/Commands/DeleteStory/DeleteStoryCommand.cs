using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.DeleteStory
{
    public class DeleteStoryCommand : IRequest
    {
        public Guid StoryId { get; set; }
    }
}
