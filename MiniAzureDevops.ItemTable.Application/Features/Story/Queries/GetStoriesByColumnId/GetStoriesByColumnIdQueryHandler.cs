using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Story.Queries.GetStoriesByColumnId
{
    public class GetStoriesByColumnIdQueryHandler : IRequestHandler<GetStoriesByColumnIdQuery, IReadOnlyCollection<StoryVm>>
    {
        private IMapper mapper;
        private readonly IStoryRepository storyRepository;

        public GetStoriesByColumnIdQueryHandler(IMapper mapper, IStoryRepository storyRepository)
        {
            this.mapper = mapper;
            this.storyRepository = storyRepository;
        }

        public async Task<IReadOnlyCollection<StoryVm>> Handle(GetStoriesByColumnIdQuery request, CancellationToken cancellationToken)
        {
            var stories = await this.storyRepository.GetStoriesByColumnId(request.ColumnId);
            return this.mapper.Map<IReadOnlyCollection<StoryVm>>(stories);
        }
    }
}
