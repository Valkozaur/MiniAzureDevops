using MiniAzureDevops.ItemTable.Domain.Common;
using MiniAzureDevops.ItemTable.Domain.Entities.Enumerations;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Item : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public ItemType Type { get; set; }

        //public Guid AssignedTo { get; set; }

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }

        public Guid ColumnId { get; set; }

        public Column Column { get; set; }

        public int? ParentId { get; set; }

        public Item Parent { get; set; }

        public ICollection<Item> Children { get; set; } = new HashSet<Item>();
    }
}
