using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.ModelConfigurations
{
    public class ItemModelConfiguration : IEntityTypeConfiguration<GetItemByIdDto>
    {
        public void Configure(EntityTypeBuilder<GetItemByIdDto> builder)
        {
            builder
                .HasKey(i => new { i.Id, i.ProjectId });

            builder
                .Property(i => i.Id)
                .UseIdentityColumn();

            builder
                .HasIndex(i => i.Name);

            builder
                .Property(i => i.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .HasOne(i => i.Parent)
                .WithMany(i => i.Children)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Column)
                .WithMany(t => t.Items)
                .OnDelete(DeleteBehavior.Restrict);

            builder
              .HasOne(i => i.Project)
              .WithMany(i => i.Items)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
