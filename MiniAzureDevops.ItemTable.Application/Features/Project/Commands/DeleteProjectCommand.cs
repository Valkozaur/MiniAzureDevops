﻿using MediatR;

namespace MiniAzureDevops.ItemTable.Application.Features.Project.Commands
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public Guid ProjectId { get; set; }
    }
}
