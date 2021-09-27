namespace RealEstateWebsite.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;
    using RealEstateWebsite.Services.Data.Interfaces;
    using RealEstateWebsite.Services.Data.ServiceModels.District;

    public class DistrictsController : Controller
    {
        private readonly IDistrictsService districtsService;
        private readonly IPropertiesService propertiesService;
        private readonly IMemoryCache memoryCache;

        public DistrictsController(
            IDistrictsService districtsService,
            IPropertiesService propertiesService,
            IMemoryCache memoryCache)
        {
            this.districtsService = districtsService;
            this.propertiesService = propertiesService;
            this.memoryCache = memoryCache;
        }

        public IActionResult All()
        {
            const string allDistrictsCacheKey = "AllDistrictsCacheKey";

            var allDistricts = this.districtsService.GetAllDistricts();

            var viewDistricts = this.SetDistrictsTotalPropertiesCount(allDistricts);

            return this.View(viewDistricts);
        }

        private IEnumerable<AllDistrictsServiceModel> SetDistrictsTotalPropertiesCount(IEnumerable<AllDistrictsServiceModel> allDistricts)
        {
            foreach (var district in allDistricts)
            {
                var properties = this.propertiesService.GetPropertiesByDistrict(district.Id);

                district.TotalProperties = properties.Count();
            }

            return allDistricts;
        }
    }
}
