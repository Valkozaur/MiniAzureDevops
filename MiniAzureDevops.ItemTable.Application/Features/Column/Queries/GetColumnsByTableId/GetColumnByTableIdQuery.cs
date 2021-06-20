using MediatR;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnByTableIdQuery : IRequest<IReadOnlyCollection<ColumnVm>>
    {
        public Guid TableId { get; set; }
    }
}
