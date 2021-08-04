namespace RealEstateWebsite.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Services.Data.ServiceModels.District;

    public class DistrictsController : Controller
    {
        private readonly IDistrictsService districtsService;
        private readonly IMemoryCache cache;

        public DistrictsController(IDistrictsService districtsService, IMemoryCache cache)
        {
            this.districtsService = districtsService;
            this.cache = cache;
        }

        public IActionResult All()
        {
            const string allDistrictsCacheKey = "AllDistrictsCacheKey";

            var allDistricts = this.cache.Get<List<AllDistrictsServiceModel>>(allDistrictsCacheKey);

            if (allDistricts == null)
            {
                allDistricts = this.districtsService
                   .GetAllDistricts()
                   .AsEnumerable()
                   .ToList();

                this.cache.Set(allDistrictsCacheKey, allDistricts);
            }

            return this.View(allDistricts);
        }
    }
}
