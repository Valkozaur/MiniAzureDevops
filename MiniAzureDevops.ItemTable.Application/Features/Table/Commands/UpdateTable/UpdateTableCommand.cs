using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest<Unit>
    {
        public ObjectId TableId { get; set; }

        public string Name { get; set; }
    }
}
