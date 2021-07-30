namespace RealEstateWebsite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;

    public class PropertiesService : IPropertiesService
    {

        private readonly ApplicationDbContext data;

        public PropertiesService(ApplicationDbContext data)
            => this.data = data;

        public void CreateProperty(
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
            int? year)
        {
            var property = new Property
            {
                Id = id,
                Interior = interior,
                Address = address,
                PictureUrl = pictureUrl,
                LivingArea = livingArea,
                Rooms = rooms,
                Floor = floor,
                TotalFloors = totalFloors,
                Year = year,
                Price = price,
                Type = propertyType,
                DistcrictId = districtId,
                EstateAgentId = estateAgentId,
            };

            this.data.Properties.Add(property);
            this.data.SaveChanges();
        }

        public IEnumerable<AllPropertiesServiceModel> GetAllProperties()
            => this.data.Properties
                .Where(p => !p.IsDeleted)
                .Select(p => new AllPropertiesServiceModel
                {
                    Id = p.Id,
                    ImageUrl = p.PictureUrl,
                    LivingArea = p.LivingArea,
                    Price = p.Price,
                    Address = p.Address,
                    Interior = p.Interior,
                    Rooms = p.Rooms,
                    Type = p.Type.ToString(),
                    District = p.District.Name,
                })
                .OrderByDescending(p => p.Price)
                .ToList();

        public IEnumerable<PropertyType> GetPropertiesTypes()
             => Enum.GetValues(typeof(PropertyType))
            .Cast<PropertyType>()
            .ToList();

        public Property GetPropertyById(int propertyId)
             => this.data.Properties
                    .FirstOrDefault(p => p.Id == propertyId);

        public void SetIsDeletedToTrue(Property property)
        {
            property.IsDeleted = true;

            this.data.SaveChanges();
        }
    }
}
