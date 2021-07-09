using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MiniAzureDevops.ItemTable.Domain.Common
{
    public class BaseEntity
    {
        [BsonId]
        public Guid _Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }

}
