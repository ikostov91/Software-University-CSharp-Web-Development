using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(x => x.BetId);

            builder.Property(x => x.Ammount)
                .IsRequired();

            builder.HasOne(x => x.Game)
                .WithMany(x => x.Bets)
                .HasForeignKey(x => x.BetId);

            builder.Property(x => x.Prediction)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.BetDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
