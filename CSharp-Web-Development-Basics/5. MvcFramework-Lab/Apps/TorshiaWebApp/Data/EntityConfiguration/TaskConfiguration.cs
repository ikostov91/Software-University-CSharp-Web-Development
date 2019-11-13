using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data.EntityConfiguration
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasMany(x => x.Participants)
                .WithOne(x => x.Task)
                .HasForeignKey(x => x.TaskId);

            builder.HasMany(x => x.AffectedSectors)
                .WithOne(x => x.Task)
                .HasForeignKey(x => x.TaskId);
        }
    }
}
