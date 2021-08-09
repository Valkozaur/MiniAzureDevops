using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.ModelConfigurations
{
    public class TableModelConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
