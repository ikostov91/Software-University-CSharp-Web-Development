using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {
            builder.ToTable("UserTeams");

            builder.HasKey(x => new {x.UserId, x.TeamId});

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserTeams)
                .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.ParticipatingUsers)
                .HasForeignKey(x => x.UserId);
        }
    }
}
