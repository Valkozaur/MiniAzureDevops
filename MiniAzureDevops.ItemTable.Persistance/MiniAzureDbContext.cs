using Microsoft.EntityFrameworkCore;
using MiniAzureDevops.ItemTable.Domain.Common;
using MiniAzureDevops.ItemTable.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MiniAzureDevops.ItemTable.Persistance
{
    public class MiniAzureDbContext : DbContext
    {
        public MiniAzureDbContext(DbContextOptions<MiniAzureDbContext> options) : base (options)
        {
        }

        public DbSet<Table> Tables { get; set; }

        public DbSet<Column> Columns { get; set; }

        public DbSet<Story> Story { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MiniAzureDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = Guid.Empty;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = Guid.Empty;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
