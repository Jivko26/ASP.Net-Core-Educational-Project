﻿namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;

    public interface IPropertiesService
    {
        IEnumerable<AllPropertiesServiceModel> GetAllProperties();

        IEnumerable<PropertyType> GetPropertiesTypes();

        void CreateProperty(
            int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year);

        void Edit(
            int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year);

        Property GetPropertyById(int propertyId);

        Property GetPropertyByDistrict(int id);

        void SetIsDeletedToTrue(Property property);
    }
}
