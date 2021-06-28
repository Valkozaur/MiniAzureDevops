using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.UpdateStory
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateStoryCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IStoryRepository storyRepository;

        public UpdateStoryCommandHandler(IMapper mapper, IStoryRepository storyRepository)
        {
            this.mapper = mapper;
            this.storyRepository = storyRepository;
        }

        public async Task<Unit> Handle(UpdateStoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStoryCommandValidator();
            var validatorResult = validator.Validate(request);

            if (!validatorResult.IsValid)
            {
                throw new Exceptions.ValidationException(validatorResult);
            }

            var storyToUpdate = await this.storyRepository.GetByIdAsync(request.Id);

            this.mapper.Map(request, storyToUpdate, typeof(UpdateStoryCommand), typeof(Domain.Entities.Story));

            await this.storyRepository.UpdateAsync(storyToUpdate);

            return Unit.Value;
        }
    }
}
