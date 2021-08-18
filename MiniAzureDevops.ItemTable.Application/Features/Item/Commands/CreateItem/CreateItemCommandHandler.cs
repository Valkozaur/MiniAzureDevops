using MediatR;
using AutoMapper;

using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;


namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemVm>
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public CreateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }

        public async Task<CreateItemVm> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = this.mapper.Map<Domain.Entities.Item>(request);
            await this.itemRepository.AddAsync(item);
            return this.mapper.Map<CreateItemVm>(item);
        }
    }
}
