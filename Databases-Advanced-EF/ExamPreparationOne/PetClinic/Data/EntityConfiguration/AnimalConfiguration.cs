using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Age)
                .IsRequired();

            builder.HasMany(x => x.Procedures)
                .WithOne(x => x.Animal)
                .HasForeignKey(x => x.AnimalId);
        }
    }
}
