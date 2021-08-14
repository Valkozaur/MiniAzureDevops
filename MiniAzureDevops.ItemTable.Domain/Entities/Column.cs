using MiniAzureDevops.ItemTable.Domain.Common;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Column : BaseEntity<Guid>
    {
        public Column() => this.Items = new HashSet<GetItemByIdDto>();

        public string Name { get; set; }

        public Guid TableId { get; set; }

        public Table Table { get; set; }

        public HashSet<GetItemByIdDto> Items { get; set; }
    }
}
