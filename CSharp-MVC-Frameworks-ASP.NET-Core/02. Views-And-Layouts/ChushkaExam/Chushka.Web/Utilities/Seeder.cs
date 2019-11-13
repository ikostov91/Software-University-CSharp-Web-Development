using Chushka.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Web.Utilities
{
    public static class Seeder
    {
        public static void Seed(IServiceProvider provider)
        { 
            var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Administrator").Result;
            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Administrator"));
            }
        }
    }
}
