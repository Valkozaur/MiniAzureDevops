using System;

namespace MiniAzureDevops.ItemTable.Application.Features.Column.Commands.CreateColumn
{
    public class CreateColumnDto
    {
        public Guid ColumnId { get; set; }

        public string Name { get; set; }

        public Guid TableId { get; set; }
    }
}