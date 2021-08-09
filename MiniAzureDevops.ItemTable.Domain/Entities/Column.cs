using MiniAzureDevops.ItemTable.Domain.Common;
using System;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Column : BaseEntity<Guid>
    {
        public Column() => this.Items = new HashSet<Item>();

        public string Name { get; set; }

        public Guid TableId { get; set; }

        public Table Table { get; set; }

        public HashSet<Item> Items { get; set; }
    }
}
