using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnsByTableIdQueryHandler : IRequestHandler<GetColumnByTableIdQuery, IReadOnlyCollection<ColumnVm>>
    {
        private readonly IMapper mapper;
        private readonly IColumnRepository columnRepository;

        public GetColumnsByTableIdQueryHandler(IMapper mapper, IColumnRepository columnRepository)
        {
            this.mapper = mapper;
            this.columnRepository = columnRepository;
        }

        public async Task<IReadOnlyCollection<ColumnVm>> Handle(GetColumnByTableIdQuery request, CancellationToken cancellationToken)
        {
            var columns = await this.columnRepository.GetColumnsByTableIdAsync(request.TableId);

            return this.mapper.Map<IReadOnlyCollection<ColumnVm>>(columns);
        }
    }
}   
