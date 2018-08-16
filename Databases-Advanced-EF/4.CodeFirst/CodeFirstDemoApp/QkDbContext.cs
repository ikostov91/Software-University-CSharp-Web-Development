using System;
using System.Collections.Generic;
using System.Text;
using CodeFirstDemoApp.POCOs;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemoApp
{
    public class QkDbContext : DbContext
    {
        private DbSet<User> Users { get; set; }
        private DbSet<File> Files { get; set; }
        private DbSet<Date> Dates { get; set; }
        private DbSet<DateFile> DateFile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Date>().HasMany(x => x.Files);
            modelBuilder.Entity<File>().HasMany(x => x.Dates);
            modelBuilder.Entity<DateFile>().HasKey(x => new { x.DateId, x.FileId });

            base.OnModelCreating(modelBuilder);
        }
    }
}