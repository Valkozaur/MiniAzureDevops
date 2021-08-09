using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.ModelConfigurations
{
    public class ProjectModelConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
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
