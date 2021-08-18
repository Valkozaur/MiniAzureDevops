using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Queries.GetColumnsByTableId
{
    public class GetColumnsByTableIdQueryHandler : IRequestHandler<GetColumnByTableIdQuery, IReadOnlyCollection<GetColumnByTableIdVm>>
    {
        private readonly IMapper mapper;
        private readonly IColumnRepository columnRepository;

        public GetColumnsByTableIdQueryHandler(IMapper mapper, IColumnRepository columnRepository)
        {
            this.mapper = mapper;
            this.columnRepository = columnRepository;
        }

        public async Task<IReadOnlyCollection<GetColumnByTableIdVm>> Handle(GetColumnByTableIdQuery request, CancellationToken cancellationToken)
        {
            var columns = await this.columnRepository.GetColumnsByTableIdAsync(request.TableId);

            return this.mapper.Map<IReadOnlyCollection<GetColumnByTableIdVm>>(columns);
        }
    }
}   
