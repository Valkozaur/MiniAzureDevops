using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniAzureDevops.ItemTable.Domain.Entities;

namespace MiniAzureDevops.ItemTable.Persistance.ModelConfigurations
{
    public class StoryItemConfiguration : IEntityTypeConfiguration<Story>
    {
        public void Configure(EntityTypeBuilder<Story> builder)
        {
            builder
                .HasKey(story => story.Id);

            builder
                .Property(story => story.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
