namespace RealEstateWebsite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;
    using RealEstateWebsite.Web.ViewModels.Administration.Properties;

    public class PropertiesService : IPropertiesService
    {

        private readonly ApplicationDbContext data;

        public PropertiesService(ApplicationDbContext data)
            => this.data = data;

        public void CreateProperty(PropertyFormModel propertyFormModel)
        {
            var property = new Property
            {
                Id = propertyFormModel.Id,
                Interior = propertyFormModel.Interior,
                Address = propertyFormModel.Address,
                PictureUrl = propertyFormModel.PictureUrl,
                LivingArea = propertyFormModel.LivingArea,
                Rooms = propertyFormModel.Rooms,
                Floor = propertyFormModel.Floor,
                TotalFloors = propertyFormModel.TotalFloors,
                Year = propertyFormModel.Year,
                Price = propertyFormModel.Price,
                Type = propertyFormModel.Type,
                DistcrictId = propertyFormModel.DistrictId,
                EstateAgentId = propertyFormModel.EstateAgentId,
            };

            this.data.Properties.Add(property);
            this.data.SaveChanges();
        }

        public void Edit(int id, PropertyFormModel propertyFormModel)
        {
            var property = this.data.Properties.FirstOrDefault(p => p.Id == id);

            if (property == null)
            {
                return;
            }

            property.Interior = propertyFormModel.Interior;
            property.Address = propertyFormModel.Address;
            property.PictureUrl = propertyFormModel.PictureUrl;
            property.LivingArea = propertyFormModel.LivingArea;
            property.Rooms = propertyFormModel.Rooms;
            property.Floor = propertyFormModel.Floor;
            property.TotalFloors = propertyFormModel.TotalFloors;
            property.Price = propertyFormModel.Price;
            property.DistcrictId = propertyFormModel.DistrictId;
            property.EstateAgentId = propertyFormModel.EstateAgentId;
            property.Type = propertyFormModel.Type;
            property.Year = propertyFormModel.Year;

            this.data.SaveChanges();
        }

        public AddPropertyFormModel PreparePropertyFormModel(Property property)
        {
            return new AddPropertyFormModel
            {
                PropertyFormModel = new PropertyFormModel
                {
                    Id = property.Id,
                    Interior = property.Interior,
                    Address = property.Address,
                    PictureUrl = property.PictureUrl,
                    LivingArea = property.LivingArea,
                    Rooms = property.Rooms,
                    Floor = property.Floor,
                    TotalFloors = property.TotalFloors,
                    Price = property.Price,
                    DistrictId = property.DistcrictId,
                    EstateAgentId = property.EstateAgentId,
                    Type = property.Type,
                    Year = property.Year,
                },
            };
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

        public Property GetPropertyByDistrict(int id)
            => this.data.Properties
            .FirstOrDefault(p => p.DistcrictId == id);

        public IEnumerable<PropertyType> GetPropertiesTypes()
             => Enum.GetValues(typeof(PropertyType))
            .Cast<PropertyType>()
            .ToList();

        public IEnumerable<Property> GetPropertiesByDistrict(int id)
            => this.data.Properties
                   .Where(p => p.DistcrictId == id && !p.IsDeleted)
                   .ToList();

        public Property GetPropertyById(int propertyId)
             => this.data.Properties
                    .Include(p => p.EstateAgent)
                    .FirstOrDefault(p => p.Id == propertyId);

        public void SetIsDeletedToTrue(Property property)
        {
            property.IsDeleted = true;

            this.data.SaveChanges();
        }
    }
}
