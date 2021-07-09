using MediatR;
using MongoDB.Bson;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommand : IRequest<CreateColumnCommandResponse>
    {
        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public ObjectId TableId { get; set; }
    }
}
