using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MishMashWebApp.Models;

namespace MishMashWebApp.Data.EntityConfiguration
{
    class UserInChannelConfiguration : IEntityTypeConfiguration<UserInChannel>
    {
        public void Configure(EntityTypeBuilder<UserInChannel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Channel)
                .WithMany(x => x.Followers)
                .HasForeignKey(x => x.ChannelId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Channels)
                .HasForeignKey(x => x.UserId);
        }
    }
}
