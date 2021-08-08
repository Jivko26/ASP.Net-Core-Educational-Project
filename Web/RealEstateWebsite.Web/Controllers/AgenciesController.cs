namespace RealEstateWebsite.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;

    public class AgenciesController : Controller
    {
        private readonly IAgenciesService agenciesService;
        private readonly IMemoryCache cache;

        public AgenciesController(IAgenciesService agenciesService, IMemoryCache cache)
        {
            this.agenciesService = agenciesService;
            this.cache = cache;
        }

        public IActionResult All()
        {
            const string allAgenciesCacheKey = "AllAgenciesCacheKey";

            var allAgencies = this.cache.Get<List<AllAgenciesServiceModel>>(allAgenciesCacheKey);

            if (allAgencies == null)
            {
                allAgencies = this.agenciesService
                   .GetAllAgencies()
                   .AsEnumerable()
                   .ToList();

                this.cache.Set(allAgenciesCacheKey, allAgencies);
            }

            return this.View(allAgencies);
        }
    }
}
