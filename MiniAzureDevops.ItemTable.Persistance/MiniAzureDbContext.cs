
using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Domain.Common;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance
{
    public class MiniAzureDbContext : DbContext
    {
        public MiniAzureDbContext(DbContextOptions<MiniAzureDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<GetItemByIdDto> Items { get; set; }

        public int MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiniAzureDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedBy = Guid.Empty;
                        break;
                    case EntityState.Modified:
                        entity.LastModifiedDate = DateTime.Now;
                        entity.LastModifiedBy = Guid.Empty;
                        break;
                }
            }
        }
    }
}
