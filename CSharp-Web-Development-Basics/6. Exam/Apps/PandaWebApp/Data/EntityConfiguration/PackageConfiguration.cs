using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PandaWebApp.Models;

namespace PandaWebApp.Data.EntityConfiguration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasOne(x => x.Recipient)
                .WithMany(x => x.Packages)
                .HasForeignKey(x => x.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Receipt)
                .WithOne(x => x.Package)
                .HasForeignKey<Receipt>(x => x.PackageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
