namespace RealEstateWebsite.Data.Services.Tests.Common
{
    using System;

    using Microsoft.EntityFrameworkCore;

    public class InMemoryFactory
    {
        public static ApplicationDbContext InitializeContext
        {
            get
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                   .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                   .Options;

                return new ApplicationDbContext(options);
            }
        }
    }
}
