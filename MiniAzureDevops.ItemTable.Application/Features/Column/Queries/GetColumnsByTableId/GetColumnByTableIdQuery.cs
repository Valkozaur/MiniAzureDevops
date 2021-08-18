using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnByTableIdQuery : IRequest<IReadOnlyCollection<GetColumnByTableIdVm>>
    {
        public Guid TableId { get; set; }
    }
}
