using System.Threading;
using System.Threading.Tasks;

using MediatR;
using AutoMapper;

using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Extensions;


namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;
        private readonly IColumnRepository columnRepository;
        private readonly ITableRepository tableRepository;

        public CreateItemCommandHandler(IMapper mapper, IItemRepository storyRepository, IColumnRepository columnRepository, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.itemRepository = storyRepository;
            this.columnRepository = columnRepository;
            this.tableRepository = tableRepository;
        }

        public async Task<CreateItemCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateItemCommandResponse();

            var validator = new CreateItemCommandValidator(this.tableRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                response.BuildErrorResponse(validationResult.Errors);
            }
            if (response.Success)
            {
                var item = this.mapper.Map<Domain.Entities.Item>(request);
                await this.itemRepository.AddAsync(item);
                response.Item = this.mapper.Map<ItemDto>(item);
            }

            return response;
        }
    }
}
