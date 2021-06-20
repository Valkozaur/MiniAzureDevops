using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Commands.CreateStory
{
    public class CreateStoryCommandHandler : IRequestHandler<CreateStoryCommand, StoryVm>
    {
        private readonly IMapper mapper;
        private readonly IStoryRepository storyRepository;
        private readonly IColumnRepository columnRepository;

        public CreateStoryCommandHandler(IMapper mapper, IStoryRepository storyRepository, IColumnRepository columnRepository)
        {
            this.mapper = mapper;
            this.storyRepository = storyRepository;
            this.columnRepository = columnRepository;
        }

        public Task<StoryVm> Handle(CreateStoryCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
