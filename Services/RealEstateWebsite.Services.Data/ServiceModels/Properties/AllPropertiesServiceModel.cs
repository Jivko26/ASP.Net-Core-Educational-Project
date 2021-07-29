namespace RealEstateWebsite.Services.Data.ServiceModels.Properties
{
    using RealEstateWebsite.Data.Models.Enum;

    public class AllPropertiesServiceModel
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Type { get; set; }

        public string Address { get; set; }

        public string District { get; set; }

        public int LivingArea { get; set; }

        public decimal Price { get; set; }

        public int Rooms { get; set; }

        public string Interior { get; set; }
    }
}
