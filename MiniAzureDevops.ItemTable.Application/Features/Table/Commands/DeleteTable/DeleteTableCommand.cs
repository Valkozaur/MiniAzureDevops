using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.DeleteTable
{
    public class DeleteTableCommand : IRequest
    {
        public Guid TableId { get; set; }
    }
}
