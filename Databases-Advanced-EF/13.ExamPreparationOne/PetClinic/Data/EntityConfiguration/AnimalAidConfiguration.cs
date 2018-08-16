using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class AnimalAidConfiguration : IEntityTypeConfiguration<AnimalAid>
    {
        public void Configure(EntityTypeBuilder<AnimalAid> builder)
        {
            builder.HasIndex(x => x.Name)
                .IsUnique();

            //builder.Property(x => x.Name)
            //    .HasMaxLength(30)
            //    .IsRequired();

            //builder.Property(x => x.Price)
            //    .IsRequired();
        }
    }
}
