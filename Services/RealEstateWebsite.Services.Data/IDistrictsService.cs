namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.District;

    public interface IDistrictsService
    {
        public IEnumerable<AllDistrictsServiceModel> GetAllDistricts();
    }
}
