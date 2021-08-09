using MediatR;
using MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn;
using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Table.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<Unit>
    {
        public string Name { get; set; }

        public CreateColumnCommand Columns { get; set; }
    }
}
