using MediatR;
using MiniAzureDevops.ItemTable.Application.Extensions;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
    {
        public CreateProjectCommandHandler(IProjectService projectService)
        {

        }

        public Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
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
            }

            return response;
        }
    }
}
