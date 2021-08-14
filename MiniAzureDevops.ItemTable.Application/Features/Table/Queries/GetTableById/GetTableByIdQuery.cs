using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<TableVm>
    {
        public Guid TableId { get; set; }
    }
}
