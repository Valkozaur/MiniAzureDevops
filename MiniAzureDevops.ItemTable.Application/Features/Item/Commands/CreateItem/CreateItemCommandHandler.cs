using MediatR;
using AutoMapper;

using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;


namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemDto>
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;
        private readonly IColumnRepository columnRepository;
        private readonly ITableRepository tableRepository;

        public CreateItemCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<CreateItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var item = this.mapper.Map<Domain.Entities.GetItemByIdDto>(request);
            await this.itemRepository.AddAsync(item);
            return this.mapper.Map<CreateItemDto>(item);
        }
    }
}
