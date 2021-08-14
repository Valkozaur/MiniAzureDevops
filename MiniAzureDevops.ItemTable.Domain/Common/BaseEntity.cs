namespace MiniAzureDevops.ItemTable.Domain.Common
{
    public class BaseEntity<TKey> : IAuditInfo
    {
        public TKey Id { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid LastModifiedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }

}
