using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetClinic.Models;

namespace PetClinic.Data.EntityConfiguration
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            //builder.HasKey(x => x.SerialNumber);

            //builder.Property(x => x.OwnerPhoneNumber)
            //    .IsRequired();

            //builder.Property(x => x.OwnerName)
            //    .HasMaxLength(30)
            //    .IsRequired();

            //builder.Property(x => x.RegistrationDate)
            //    .IsRequired();
        }
    }
}
