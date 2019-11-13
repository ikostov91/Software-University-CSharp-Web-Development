using Eventures.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eventures.Data
{
    public class EventuresDbContext : IdentityDbContext<EventureUser>
    {
        public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventureEvent> EventureEvents { get; set; }
        public DbSet<CustomLog> Logs { get; set; }
        public DbSet<EventureOrder> Orders { get; set; }
    }
}
