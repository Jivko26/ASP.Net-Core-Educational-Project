namespace RealEstateWebsite.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class RealEstateAgenciesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.RealEstateAgents.Any())
            {
                return;
            }

            //await dbContext.RealEstateAgents.AddAsync();
        }
    }
}
