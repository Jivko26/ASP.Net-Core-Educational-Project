namespace RealEstateWebsite.Services.Data.ServiceModels.District
{
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Mapping;

    public class AllDistrictsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalProperties { get; set; }
    }
}
