using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
