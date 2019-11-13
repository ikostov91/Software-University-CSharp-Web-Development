using Chushka.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Chushka.Data
{
    public class ChushkaDbContext : IdentityDbContext<ChushkaUser>
    {
        public ChushkaDbContext(DbContextOptions<ChushkaDbContext> options)
            : base(options)
        {
        }

        // This DBset<> is not required. Already have users
        // public DbSet<ChushkaUser> Users { get; set; }

        public DbSet<Product> Products{ get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
