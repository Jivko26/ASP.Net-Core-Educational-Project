namespace RealEstateWebsite.Services.Data.ServiceModels.Posts
{
    public class PostDetailsModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PropertyPictureUrl { get; set; }

        public string PropertyInterior { get; set; }

        public decimal PropertyPrice { get; set; }

        public int PropertyRooms { get; set; }

        public int PropertyLivingArea { get; set; }

        public int PropertyFloor { get; set; }

        public int PropertyTotalFloors { get; set; }

        public int? PropertyYear { get; set; }

        public int PropertyEstateAgentId { get; set; }

        public string PropertyEstateAgentName { get; set; }

        public string PropertyEstateAgentPhone { get; set; }

        public string PropertyEstateAgentWebsite { get; set; }
    }
}
