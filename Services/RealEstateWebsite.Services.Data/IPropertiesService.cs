namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.Properties;

    public interface IPropertiesService
    {
        IEnumerable<AllPropertiesServiceModel> GetAllProperties();
    }
}
