using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTablesByProjectId
{
    public class GetTablesByProjectIdQueryHandler : IRequestHandler<GetTablesByProjectIdQuery, IEnumerable<GetTablesByProjectIdVm>>
    {
        private readonly ITableRepository tableRepository;

        public GetTablesByProjectIdQueryHandler(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task<IEnumerable<GetTablesByProjectIdVm>> Handle(GetTablesByProjectIdQuery request, CancellationToken cancellationToken)
            => await this.tableRepository.GetByProjectIdAsync<GetTablesByProjectIdVm>(request.ProjectId);
    }
}
