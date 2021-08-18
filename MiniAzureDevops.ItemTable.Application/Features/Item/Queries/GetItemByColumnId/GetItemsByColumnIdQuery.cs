using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetItemsByColumnIdQuery : IRequest<IReadOnlyCollection<GetItemByIdVm>>
    {
        public Guid ColumnId { get; set; } 
    }
}
