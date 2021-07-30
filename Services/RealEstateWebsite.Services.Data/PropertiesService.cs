namespace RealEstateWebsite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Properties;

    public class PropertiesService : IPropertiesService
    {

        private readonly ApplicationDbContext data;

        public PropertiesService(ApplicationDbContext data)
            => this.data = data;

        public IEnumerable<AllPropertiesServiceModel> GetAllProperties()
            => this.data.Properties
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedOn)
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
                .ToList();

        public IEnumerable<PropertyType> GetPropertiesTypes()
             => Enum.GetValues(typeof(PropertyType))
            .Cast<PropertyType>()
            .ToList();
    }
}
