using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.UpdateColumn
{
    public class UpdateColumnCommand : IRequest
    {
        public Guid ColumnId { get; set; }

        public string Name { get; set; }

        public Guid TableId { get; set; }
    }
}
