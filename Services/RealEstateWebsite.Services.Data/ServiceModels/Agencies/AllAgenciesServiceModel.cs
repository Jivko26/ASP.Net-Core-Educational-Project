namespace RealEstateWebsite.Services.Data.ServiceModels.Agencies
{
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Mapping;

    public class AllAgenciesServiceModel
    {

        public int AgentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PropertiesCount { get; set; }
    }
}
