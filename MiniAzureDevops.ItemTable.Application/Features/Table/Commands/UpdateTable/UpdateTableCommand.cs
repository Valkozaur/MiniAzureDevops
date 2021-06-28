using MediatR;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest<Unit>
    {
        public Guid TableId { get; set; }

        public string Name { get; set; }
    }
}
