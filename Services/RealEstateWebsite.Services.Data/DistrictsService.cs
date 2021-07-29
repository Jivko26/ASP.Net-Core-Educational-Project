namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Services.Data.ServiceModels.District;

    public class DistrictsService : IDistrictsService
    {
        private readonly ApplicationDbContext data;

        public DistrictsService(ApplicationDbContext data)
            => this.data = data;

        public IEnumerable<AllDistrictsServiceModel> GetAllDistricts()
            => this.data.Districts
                .Select(d => new AllDistrictsServiceModel
                {
                    Name = d.Name,
                    TotalProperties = d.Properties.Count(),
                })
                .OrderBy(t => t.Name)
                .ToList();

    }
}
