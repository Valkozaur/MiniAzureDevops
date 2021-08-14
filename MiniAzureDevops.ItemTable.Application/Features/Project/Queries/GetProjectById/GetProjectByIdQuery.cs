using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDto>
    {
        public Guid ProjectId { get; set; }
    }
}
