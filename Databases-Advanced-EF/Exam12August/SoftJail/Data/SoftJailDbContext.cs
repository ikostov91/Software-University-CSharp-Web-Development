﻿using SoftJail.Data.EntityConfiguration;
using SoftJail.Data.Models;

namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cell> Cells { get; set; }
        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Prisoner> Prisoners { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CellConfiguration());
            builder.ApplyConfiguration(new MailConfiguration());
            builder.ApplyConfiguration(new OfficerPrisonerConfiguration());
            builder.ApplyConfiguration(new PrisonerConfiguration());
        }
    }
}