using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.DeleteColumn
{
    public class DeleteColumnCommand : IRequest
    {
        public ObjectId ColumnId { get; set; }
    }
}
