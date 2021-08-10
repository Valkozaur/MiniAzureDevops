using MediatR;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetItemsByColumnIdQuery : IRequest<IReadOnlyCollection<ItemVm>>
    {
        public Guid ColumnId { get; set; } 
    }
}
