namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.District;

    public interface IDistrictsService
    {
        IEnumerable<AllDistrictsServiceModel> GetAllDistricts();

        bool DistrictExists(int districtId);
    }
}
