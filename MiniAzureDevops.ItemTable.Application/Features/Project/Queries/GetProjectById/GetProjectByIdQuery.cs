using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<GetProjectByIdDto>
    {
        public Guid ProjectId { get; set; }
    }
}
