namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;

    public interface IAgenciesService
    {
        IEnumerable<AllAgenciesServiceModel> GetAllAgencies();
    }
}
