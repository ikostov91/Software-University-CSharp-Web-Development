using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data.EntityConfiguration
{
    class ChannelTagConfiguration : IEntityTypeConfiguration<ChannelTag>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ChannelTag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Channel)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.ChannelId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.Channels)
                .HasForeignKey(x => x.TagId);
        }
    }
}
