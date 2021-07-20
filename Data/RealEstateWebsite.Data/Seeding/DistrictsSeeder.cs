namespace RealEstateWebsite.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using RealEstateWebsite.Data.Models;

    internal class DistrictsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Districts.Any())
            {
                return;
            }

            await dbContext.Districts.AddAsync(new District 
            {
                Name = "Rotterdam",
            });

            await dbContext.Districts.AddAsync(new District
            {
                Name = "Amsterdam",
            });

            await dbContext.Districts.AddAsync(new District
            {
                Name = "The Hague",
            });

            await dbContext.Districts.AddAsync(new District
            {
                Name = "Leiden",
            });

            await dbContext.Districts.AddAsync(new District
            {
                Name = "Eindhoven",
            });
        }
    }
}
