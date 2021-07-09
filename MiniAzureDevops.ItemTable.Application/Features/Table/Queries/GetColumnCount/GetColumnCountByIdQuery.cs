using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetColumnCount
{
    public class GetColumnCountByIdQuery : IRequest<int>
    {
        public ObjectId TableId { get; set; }
    }
}
