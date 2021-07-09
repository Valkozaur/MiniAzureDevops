using MiniAzureDevops.ItemTable.Domain.Common;
using MongoDB.Bson;
using System.Collections.Generic;

namespace MiniAzureDevops.ItemTable.Domain.Entities
{
    public class Column : BaseEntity
    {
        public string Name { get; set; }

        public ObjectId TableId { get; set; }

        public Table Table { get; set; }

        public HashSet<Story> Stories { get; set; } = new HashSet<Story>();
    }
}
