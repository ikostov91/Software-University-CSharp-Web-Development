using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data.EntityConfiguration
{
    public class PrisonerConfiguration : IEntityTypeConfiguration<Prisoner>
    {
        public void Configure(EntityTypeBuilder<Prisoner> builder)
        {
            builder.HasOne(x => x.Cell)
                .WithMany(x => x.Prisoners)
                .HasForeignKey(x => x.CellId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}

