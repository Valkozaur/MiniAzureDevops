using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.UpdateStory
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IItemRepository itemRepository;

        public UpdateStoryCommandHandler(IMapper mapper, IItemRepository itemRepository)
        {
            this.mapper = mapper;
            this.itemRepository = itemRepository;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await this.itemRepository.GetByIdAsync(request.Id, request.ProjectId);

            this.mapper.Map(request, item, typeof(UpdateItemCommand), typeof(GetItemByIdDto));

            this.itemRepository.Update(item);

            return Unit.Value;
        }
    }
}
