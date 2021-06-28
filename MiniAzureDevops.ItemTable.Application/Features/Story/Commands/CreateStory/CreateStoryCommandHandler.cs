using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Extensions;
using MiniAzureDevops.ItemTable.Application.Features.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, CreateStoryCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IStoryRepository storyRepository;
        private readonly IColumnRepository columnRepository;
        private readonly ITableRepository tableRepository;

        public CreateStoryCommandHandler(IMapper mapper, IStoryRepository storyRepository, IColumnRepository columnRepository, ITableRepository tableRepository)
        {
            this.mapper = mapper;
            this.storyRepository = storyRepository;
            this.columnRepository = columnRepository;
            this.tableRepository = tableRepository;
        }

        public async Task<CreateStoryCommandResponse> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateStoryCommandResponse();
            request.TableId = TableIdGenerator.GetRandomTableId();

            var validator = new CreateStoryCommandValidator(this.tableRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                while(validationResult.Errors.Any(x => x.ErrorCode == "NotTableUniqueId"))
                {
                    request.TableId = TableIdGenerator.GetRandomTableId();
                    validationResult = await validator.ValidateAsync(request);
                }

                if(!validationResult.IsValid) 
                    response.BuildErrorResponse(validationResult.Errors);
            }
            if (response.Success)
            {
                var story = this.mapper.Map<Domain.Entities.Story>(request);
                story = await this.storyRepository.AddAsync(story);
                response.Story = this.mapper.Map<StoryDto>(story);
            }

            return response;
        }
    }
}
