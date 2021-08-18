using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<GetTableByIdVm>
    {
        public Guid TableId { get; set; }
    }
}
