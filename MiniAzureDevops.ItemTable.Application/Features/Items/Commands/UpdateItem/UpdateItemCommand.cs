using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.UpdateStory
{
    public class UpdateItemCommand : IRequest<Unit>
    {
        public int Id { get;set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderNumber { get; set; }

        public string AssignedTo { get; set; }

        public string ColumnId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
