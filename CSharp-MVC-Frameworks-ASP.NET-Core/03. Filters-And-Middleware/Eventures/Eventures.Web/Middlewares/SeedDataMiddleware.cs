
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Eventures.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Eventures.Data;

namespace Eventures.Web.Middlewares
{
    public class SeedDataMiddleware
    {
        private readonly RequestDelegate next;

        public SeedDataMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, 
            EventuresDbContext dbContext, 
            UserManager<EventureUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (!dbContext.EventureEvents.Any())
            {
                this.SeedEvents(dbContext);
            }

            if (!dbContext.Roles.Any())
            {
                await this.SeedRoles(userManager, roleManager);
            }

            if (dbContext.Users.Any() && dbContext.Users.Count() == 1)
            {
                await this.AssignAdminUser(userManager);
            }

            await this.next(context);
        }

        private async Task SeedRoles(UserManager<EventureUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Administrator"));
            if (result.Succeeded && userManager.Users.Any())
            {
                var firstUser = userManager.Users.FirstOrDefault();
                await userManager.AddToRoleAsync(firstUser, "Administrator");
            }
        }

        private void SeedEvents(EventuresDbContext dbContext)
        {
            //for (int i = 1; i <= 10; i++)
            //{
            //    var sampleEvent = new EventureEvent()
            //    {
            //        Name = $"Sample event number {i}",
            //        Place = $"Sample place address 100{i}",
            //        Start = DateTime.UtcNow.Add(TimeSpan.FromDays(i)),
            //        End = DateTime.UtcNow.Add(TimeSpan.FromDays(i * 2)),
            //        TicketPrice = 10 + i,
            //        TotalTickets = i * 100
            //    };
            //    dbContext.EventureEvents.Add(sampleEvent);
            //}
            var sampleEvent = new EventureEvent()
            {
                Name = $"Sample Event",
                Place = $"Some Address",
                Start = DateTime.UtcNow.Add(TimeSpan.FromDays(10)),
                End = DateTime.UtcNow.Add(TimeSpan.FromDays(10 * 2)),
                TicketPrice = 5,
                TotalTickets = 20
            };
            dbContext.EventureEvents.Add(sampleEvent);
            dbContext.SaveChanges();
        }

        private async Task AssignAdminUser(UserManager<EventureUser> userManager)
        {
            var firstUser = userManager.Users.FirstOrDefault();
            await userManager.AddToRoleAsync(firstUser, "Administrator");
        }
    }
}
