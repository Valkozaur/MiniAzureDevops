using System;
using System.Collections.Generic;

using MiniAzureDevops.ItemTable.Domain.Common;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Table : BaseEntity<Guid>
    {
        public string Name { get; set; }

        public HashSet<Column> Columns { get; set; } = new HashSet<Column>();

        public Guid ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
