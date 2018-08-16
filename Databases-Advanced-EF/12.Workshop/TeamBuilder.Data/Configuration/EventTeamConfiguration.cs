﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configuration
{
    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeam>
    {
        public void Configure(EntityTypeBuilder<EventTeam> builder)
        {
            builder.ToTable("EventTeams");

            builder.HasKey(x => new {x.EventId, x.TeamId});

            builder.HasOne(x => x.Event)
                .WithMany(x => x.ParticipatingEventTeams)
                .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.EventTeams)
                .HasForeignKey(x => x.EventId);
        }
    }
}
