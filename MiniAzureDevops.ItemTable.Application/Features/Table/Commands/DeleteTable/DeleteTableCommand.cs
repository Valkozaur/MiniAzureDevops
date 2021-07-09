using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.DeleteTable
{
    public class DeleteTableCommand : IRequest
    {
        public ObjectId TableId { get; set; }
    }
}
