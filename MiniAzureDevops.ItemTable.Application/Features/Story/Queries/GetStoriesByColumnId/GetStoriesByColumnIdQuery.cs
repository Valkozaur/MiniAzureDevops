using MediatR;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetStoriesByColumnIdQuery : IRequest<IReadOnlyCollection<StoryVm>>
    {
        public Guid ColumnId { get; set; }
    }
}
