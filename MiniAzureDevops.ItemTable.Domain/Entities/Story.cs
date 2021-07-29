
using MiniAzureDevops.ItemTable.Domain.Common;
using System;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Story : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderNumber { get; set; }

        public string AssignedTo { get; set; }

        public Guid ColumnId { get; set; }

        public Column Column { get; set; }

        public Guid TableId { get; set; }

        public Table Table { get; set; }
    }
}
