namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;

    public interface IPropertiesService
    {
        IEnumerable<AllPropertiesServiceModel> GetAllProperties();

        IEnumerable<PropertyType> GetPropertiesTypes();

    }
}
