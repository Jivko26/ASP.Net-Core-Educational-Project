namespace RealEstateWebsite.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using RealEstateWebsite.Common;
    using RealEstateWebsite.Data.Models;

    public class AdministratorSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any(u => u.Email == "admin@crs.com"))
            {
                return;
            }

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            const string adminEmail = "admin@crs.com";
            const string adminPassword = "admin12";

            var user = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminEmail,
            };

            await userManager.CreateAsync(user, adminPassword);

            await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
        }
    }
}
