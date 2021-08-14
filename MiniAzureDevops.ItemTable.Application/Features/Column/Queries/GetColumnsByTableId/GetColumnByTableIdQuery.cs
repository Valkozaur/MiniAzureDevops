using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnByTableIdQuery : IRequest<IReadOnlyCollection<ColumnVm>>
    {
        public Guid TableId { get; set; }
    }
}
