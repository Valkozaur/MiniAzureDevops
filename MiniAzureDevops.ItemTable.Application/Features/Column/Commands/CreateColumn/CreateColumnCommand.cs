using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnCommand : IRequest<CreateColumnCommandResponse>
    {
        public string Name { get; set; }

        public Guid TableId { get; set; }
    }
}
