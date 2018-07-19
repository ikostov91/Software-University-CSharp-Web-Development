﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class PlayerStatisticConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        void IEntityTypeConfiguration<PlayerStatistic>.Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(x => new {x.PlayerId, x.GameId});

            builder.HasOne(x => x.Player)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.PlayerId);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.GameId);
        }
    }
}
