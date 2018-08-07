using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(32);

            builder.Property(x => x.Acronym)
                .IsRequired();

            builder.HasMany(x => x.Invitations)
                .WithOne(x => x.Team)
                .HasForeignKey(x => x.TeamId);
        }
    }
}
