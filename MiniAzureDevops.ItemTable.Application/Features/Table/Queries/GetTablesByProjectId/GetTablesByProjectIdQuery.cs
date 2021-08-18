using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTablesByProjectId
{
    public class GetTablesByProjectIdQuery : IRequest<IEnumerable<GetTablesByProjectIdVm>>
    {
        public Guid ProjectId { get; set; }
    }
}
