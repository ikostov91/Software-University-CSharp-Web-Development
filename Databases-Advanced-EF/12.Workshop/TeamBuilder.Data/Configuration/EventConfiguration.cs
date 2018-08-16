namespace TeamBuilder.Data.Configuration
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TeamBuilder.Models;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(25);

            builder.Property(x => x.Description)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(250);
        }
    }
}
