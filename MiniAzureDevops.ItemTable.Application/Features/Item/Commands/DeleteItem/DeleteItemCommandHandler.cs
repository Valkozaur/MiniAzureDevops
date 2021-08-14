using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.DeleteStory
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteStoryCommand, Unit>
    {
        private readonly IItemRepository itemRepository;

        public DeleteItemCommandHandler(IItemRepository storyRepository)
        {
            this.itemRepository = storyRepository;
        }

        public async Task<Unit> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            var item = await this.itemRepository.GetByIdAsync(request.ItemId, request.ProjectId);
            this.itemRepository.Delete(item);
            await this.itemRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
