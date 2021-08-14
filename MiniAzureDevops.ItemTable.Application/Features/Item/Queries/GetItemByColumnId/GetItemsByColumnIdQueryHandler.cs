using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetItemsByColumnIdQueryHandler : IRequestHandler<GetItemsByColumnIdQuery, IReadOnlyCollection<ItemVm>>
    {
        private IMapper mapper;
        private readonly IItemRepository itemRepository;

        public GetItemsByColumnIdQueryHandler(IMapper mapper, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        public async Task<IReadOnlyCollection<ItemVm>> Handle(GetItemsByColumnIdQuery request, CancellationToken cancellationToken)
        {
            var stories = await this.itemRepository.GetItemsByColumnId(request.ColumnId);
            return this.mapper.Map<IReadOnlyCollection<ItemVm>>(stories);
        }
    }
}
