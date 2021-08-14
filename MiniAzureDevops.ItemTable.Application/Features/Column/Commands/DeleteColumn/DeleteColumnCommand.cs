using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.DeleteColumn
{
    public class DeleteColumnCommand : IRequest
    {
        public Guid ColumnId { get; set; }
    }
}
