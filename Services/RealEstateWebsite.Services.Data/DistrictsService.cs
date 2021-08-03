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

        public bool DistrictExists(int districtId)
            => this.data.Districts
                   .Any(d => d.Id == districtId);

        public IEnumerable<AllDistrictsServiceModel> GetAllDistricts()
            => this.data.Districts
                .Where(d => !d.IsDeleted)
                .Select(d => new AllDistrictsServiceModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    TotalProperties = this.data.Properties
                    .Where(p => p.DistcrictId == d.Id)
                    .Count(),
                })
                .OrderByDescending(t => t.TotalProperties)
                .ToList();

    }
}
