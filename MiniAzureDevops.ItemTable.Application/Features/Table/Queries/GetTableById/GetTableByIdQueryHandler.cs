using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Queries.GetTableById
{
    public class GetTableByIdQueryHandler : IRequestHandler<GetTableByIdQuery, TableVm>
    {
        private readonly ITableRepository tableRepository;
        private readonly IMapper _mapper;

        public GetTableByIdQueryHandler(ITableRepository _tableRepository, IMapper mapper)
        {
            tableRepository = _tableRepository;
            _mapper = mapper;
        }
        public async Task<TableVm> Handle(GetTableByIdQuery request, CancellationToken cancellationToken)
        {
            var table = await this.tableRepository.GetByIdAsync(request.Id);
            return this._mapper.Map<TableVm>(table);
        }
    }
}
