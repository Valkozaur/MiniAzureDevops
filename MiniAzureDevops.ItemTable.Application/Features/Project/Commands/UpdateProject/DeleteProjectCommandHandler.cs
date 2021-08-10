using MediatR;
using MiniAzureDevops.ItemTable.Application.Contracts.Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.UpdateProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IProjectRepository projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await this.projectRepository.GetProjectById(request.ProjectId);
            this.projectRepository.Delete(project);
            await this.projectRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
