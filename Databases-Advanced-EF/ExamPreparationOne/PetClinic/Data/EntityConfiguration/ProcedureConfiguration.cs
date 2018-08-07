using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class ProcedureConfiguration : IEntityTypeConfiguration<Procedure>
    {
        public void Configure(EntityTypeBuilder<Procedure> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Animal)
                .IsRequired();

            builder.Property(x => x.Vet)
                .IsRequired();

            builder.HasOne(x => x.Vet)
                .WithMany(x => x.Procedures)
                .HasForeignKey(x => x.VetId);

            builder.Property(x => x.DateTime)
                .IsRequired();
        }
    }
}
