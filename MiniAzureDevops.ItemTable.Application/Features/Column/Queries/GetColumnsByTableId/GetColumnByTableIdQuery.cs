using MediatR;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnByTableIdQuery : IRequest<IReadOnlyCollection<ColumnVm>>
    {
        public ObjectId TableId { get; set; }
    }
}
