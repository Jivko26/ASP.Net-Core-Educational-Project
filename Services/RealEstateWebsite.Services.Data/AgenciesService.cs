namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;

    public class AgenciesService : IAgenciesService
    {
        private readonly ApplicationDbContext data;

        public AgenciesService(ApplicationDbContext data)
            => this.data = data;

        public IEnumerable<AllAgenciesServiceModel> GetAllAgencies()
            => this.data.RealEstateAgents
                .Where(a => !a.IsDeleted)
                .Select(a => new AllAgenciesServiceModel
                {
                    AgentId = a.Id,
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
