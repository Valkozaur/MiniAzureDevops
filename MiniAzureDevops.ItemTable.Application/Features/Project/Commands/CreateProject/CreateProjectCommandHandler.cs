using AutoMapper;
using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using MiniAzureDevops.ItemTable.Application.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;

        public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectCommandValidator();
            var validatonResult = validator.Validate(request);

            var response = new CreateProjectCommandResponse();
            if (!validatonResult.IsValid)
            {
                response.BuildErrorResponse(validatonResult.Errors);
            }

            if (response.Success)
            {
                var project = new Domain.Entities.Project() { Name = request.Name };
                await this.projectRepository.AddAsync(project);
                await this.projectRepository.SaveChangesAsync();
                response.Project = this.mapper.Map<ProjectDto>(project);
            }

            return response;
        }
    }
}
