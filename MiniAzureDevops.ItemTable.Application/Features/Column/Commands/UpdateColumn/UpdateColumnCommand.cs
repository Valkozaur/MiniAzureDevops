using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.UpdateColumn
{
    public class UpdateColumnCommand : IRequest
    {
        public ObjectId ColumnId { get; set; }

        public string Name { get; set; }

        public ObjectId TableId { get; set; }
    }
}
