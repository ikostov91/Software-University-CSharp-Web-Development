using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class VetConfiguration : IEntityTypeConfiguration<Vet>
    {
        public void Configure(EntityTypeBuilder<Vet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Profession)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Age)
                .IsRequired();

            builder.HasIndex(x => x.PhoneNumber)
                .IsUnique();

            builder.Property(x => x.PhoneNumber)
                .IsRequired();
        }
    }
}
