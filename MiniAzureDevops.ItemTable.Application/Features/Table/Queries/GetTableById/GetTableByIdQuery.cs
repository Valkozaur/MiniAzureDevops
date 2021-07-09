using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<TableVm>
    {
        public ObjectId Id { get; set; }
    }
}
