using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Exceptions;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, GetProjectByIdDto>
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;

        public GetProjectByIdQueryHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        public async Task<GetProjectByIdDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.GetProjectById<GetProjectByIdDto>(request.ProjectId);

            if (project == null)
                throw new NotFoundException("Project", request.ProjectId);

            return project;
        }
    }
}
