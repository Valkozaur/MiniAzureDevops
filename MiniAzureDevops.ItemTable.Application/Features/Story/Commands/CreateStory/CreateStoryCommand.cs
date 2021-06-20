using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommand : IRequest<StoryVm>
    {
        public string Name { get; set; }

        public Guid ColumnId { get; set; }
    }
}
