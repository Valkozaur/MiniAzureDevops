using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.DeleteStory
{
    public class DeleteStoryCommandHandler : IRequestHandler<DeleteStoryCommand, Unit>
    {
        private readonly IStoryRepository storyRepository;

        public DeleteStoryCommandHandler(IStoryRepository storyRepository)
        {
            this.storyRepository = storyRepository;
        }

        public async Task<Unit> Handle(DeleteStoryCommand request, CancellationToken cancellationToken)
        {
            await this.storyRepository.DeleteAsync(request.StoryId);

            return Unit.Value;
        }
    }
}
