
using MiniAzureDevops.ItemTable.Domain.Common;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Story : BaseEntity
    {
        public int TableId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderNumber { get; set; }

        public string Comments { get; set; }

        public string AssignedTo { get; set; }

        public string ColumnId { get; set; }

        public Column Column { get; set; }
    }
}
