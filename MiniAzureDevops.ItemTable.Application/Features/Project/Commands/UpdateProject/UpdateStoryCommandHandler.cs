using AutoMapper;
using MediatR;

using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateStoryCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;

        public UpdateStoryCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.GetProjectById(request.Id);
            this.mapper.Map(request, project, typeof(UpdateProjectCommand), typeof(Domain.Entities.Project));

            this.projectRepository.Update(project);
            await this.projectRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
