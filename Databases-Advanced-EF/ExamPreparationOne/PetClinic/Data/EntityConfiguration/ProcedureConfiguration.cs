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
            //builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Vet)
                .WithMany(x => x.Procedures)
                .HasForeignKey(x => x.VetId);

            //builder.Property(x => x.DateTime)
            //    .IsRequired();
        }
    }
}
