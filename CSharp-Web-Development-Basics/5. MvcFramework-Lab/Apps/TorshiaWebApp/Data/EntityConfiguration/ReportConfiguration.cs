using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorshiaWebApp.Models;

namespace TorshiaWebApp.Data.EntityConfiguration
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasOne(x => x.Reporter)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.ReporterId);

            builder.HasOne(x => x.Task)
                .WithMany(x => x.Reports)
                .HasForeignKey(x => x.TaskId);
        }
    }
}
