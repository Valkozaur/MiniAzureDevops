using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Exceptions;
using MiniAzureDevops.ItemTable.Application.Features.Project.Dtos;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDto>
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;

        public GetProjectByIdQueryHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        public async Task<ProjectDto> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.GetProjectById(request.ProjectId);

            if (project == null)
                throw new NotFoundException("Project", request.ProjectId);

            return this.mapper.Map<ProjectDto>(project);

        }
    }
}
