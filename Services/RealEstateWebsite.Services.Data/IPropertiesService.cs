namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;
    using RealEstateWebsite.Web.ViewModels.Administration.Properties;

    public interface IPropertiesService
    {
        IEnumerable<AllPropertiesServiceModel> GetAllProperties();

        IEnumerable<PropertyType> GetPropertiesTypes();

        void CreateProperty(PropertyFormModel propertyFormModel);

        void Edit(PropertyFormModel propertyFormModel);

        Property GetPropertyByDistrict(int id);

        Property GetPropertyById(int propertyId);

        IEnumerable<Property> GetPropertiesByDistrict(int id);

        void SetIsDeletedToTrue(Property property);
    }
}
