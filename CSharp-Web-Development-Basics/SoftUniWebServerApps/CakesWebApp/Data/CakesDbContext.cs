namespace CakesWebApp.Data
{
    using CakesWebApp.Models;
    using Microsoft.EntityFrameworkCore;

    public class CakesDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-5BO26G8\SQLEXPRESS;Database=Cakes;Integrated Security=True");
            }
        }
    }
}
