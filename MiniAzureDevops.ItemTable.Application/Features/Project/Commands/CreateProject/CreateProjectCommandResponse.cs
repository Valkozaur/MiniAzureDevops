using MiniAzureDevops.ItemTable.Application.Responses;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.CreateProject
{
    public class CreateProjectCommandResponse : BaseResponse
    {
        public ProjectDto Project { get; set; }
    }
}
