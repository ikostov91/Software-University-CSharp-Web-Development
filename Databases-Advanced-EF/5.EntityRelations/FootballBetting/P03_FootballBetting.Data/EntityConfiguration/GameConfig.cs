using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.GameId);

            builder.Property(x => x.AwayTeamBetRate)
                .IsRequired();

            builder.Property(x => x.AwayTeamGoals)
                .IsRequired();

            builder.HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .HasForeignKey(x => x.AwayTeamId);

            builder.Property(x => x.DrawBetRate)
                .IsRequired();

            builder.Property(x => x.HomeTeamBetRate)
                .IsRequired();

            builder.Property(x => x.HomeTeamGoals)
                .IsRequired();

            builder.HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(x => x.HomeTeamId);

            builder.Property(x => x.Result)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.GameDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.HasMany(x => x.Bets)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);
        }
    }
}
