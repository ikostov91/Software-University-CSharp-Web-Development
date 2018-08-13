using System;
using System.Collections.Generic;
using System.Text;
using FastFood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastFood.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Employee)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.EmployeeId);
        }
    }
}
