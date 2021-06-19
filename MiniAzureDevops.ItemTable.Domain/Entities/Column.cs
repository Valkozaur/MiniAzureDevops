using MiniAzureDevops.ItemTable.Domain.Common;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Column : BaseEntity
    {
        public string Name { get; set; }

        public string TableId { get; set; }

        public Table Table { get; set; }

        public HashSet<Story> Stories { get; set; } = new HashSet<Story>();
    }
}
