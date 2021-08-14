using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommand : IRequest<CreateColumnDto>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int OrderNumber { get; set; }

        public Guid TableId { get; set; }
    }
}
