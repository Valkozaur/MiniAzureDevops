using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectDto>
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;

        public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        public async Task<CreateProjectDto> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Domain.Entities.Project() { Name = request.Name };
            await this.projectRepository.AddAsync(project);
            await this.projectRepository.SaveChangesAsync();
            return this.mapper.Map<CreateProjectDto>(project);
        }
    }
}
