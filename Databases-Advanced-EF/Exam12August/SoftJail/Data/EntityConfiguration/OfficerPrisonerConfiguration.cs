using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftJail.Data.Models;

namespace SoftJail.Data.EntityConfiguration
{
    public class OfficerPrisonerConfiguration : IEntityTypeConfiguration<OfficerPrisoner>
    {
        public void Configure(EntityTypeBuilder<OfficerPrisoner> builder)
        {
            builder.HasKey(x => new { x.PrisonerId, x.OfficerId });

            builder.HasOne(x => x.Prisoner)
                .WithMany(x => x.PrisonerOfficers)
                .HasForeignKey(x => x.PrisonerId);

            builder.HasOne(x => x.Officer)
                .WithMany(x => x.OfficerPrisoners)
                .HasForeignKey(x => x.OfficerId);
        }
    }
}
