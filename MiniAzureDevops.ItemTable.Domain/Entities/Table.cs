using MiniAzureDevops.ItemTable.Domain.Common;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Table : BaseEntity
    {
        public string Name { get; set; }

        public HashSet<Column> Columns { get; set; } = new HashSet<Column>();
    }
}
