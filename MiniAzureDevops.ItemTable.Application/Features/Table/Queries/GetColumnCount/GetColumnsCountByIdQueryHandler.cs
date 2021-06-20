using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetColumnCount
{
    public class GetColumnsCountByIdQueryHandler : IRequestHandler<GetColumnCountByIdQuery, int>
    {
        private readonly ITableRepository tableRepository;

        public GetColumnsCountByIdQueryHandler(ITableRepository tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public Task<int> Handle(GetColumnCountByIdQuery request, CancellationToken cancellationToken)
            => this.tableRepository.GetColumnCountByIdAsync(request.TableId);
    }
}
