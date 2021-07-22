namespace RealEstateWebsite.Services.Data.ServiceModels.Agencies
{

    public class AllAgenciesServiceModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int TotalPropertiesCount { get; set; }
    }
}
