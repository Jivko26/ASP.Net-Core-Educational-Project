﻿namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;

    public class AgenciesService : IAgenciesService
    {
        private readonly ApplicationDbContext data;

        public AgenciesService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<AllAgenciesServiceModel> GetAllAgencies()
        {
            return this.data.RealEstateAgents
                .Select(a => new AllAgenciesServiceModel
                {
                    Name = a.Name,
                    Description = a.Description,
                    Address = a.OfficeLocation,
                    Email = a.ContactEmail,
                    PhoneNumber = a.Telephone,
                    TotalPropertiesCount = a.Properties.Count(),
                })
                .OrderByDescending(ea => ea.TotalPropertiesCount)
                .ToList();
        }
    }
}
