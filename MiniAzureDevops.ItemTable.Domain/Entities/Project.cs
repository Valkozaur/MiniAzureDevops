using MiniAzureDevops.ItemTable.Domain.Common;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Project : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public ICollection<Table> Tables { get; set; } = new HashSet<Table>();

        public ICollection<GetItemByIdDto> Items { get; set; } = new HashSet<GetItemByIdDto>();
    }
}
    