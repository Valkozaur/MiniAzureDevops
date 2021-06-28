using MiniAzureDevops.ItemTable.Domain.Common;
using MiniAzureDevops.ItemTable.Domain.Entities.Enumerations;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Item : BaseEntity
    {
        public int TableId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ItemStatus ItemStatus { get; set; }

        public string AssignedTo { get; set; }

        public string StoryId { get; set; }

        public Story Story { get; set; }
    }
}
