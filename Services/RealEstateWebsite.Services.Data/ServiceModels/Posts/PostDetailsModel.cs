namespace RealEstateWebsite.Services.Data.ServiceModels.Posts
{
    public class PostDetailsModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PropertyPictureUrl { get; set; }

        public string PropertyInterior { get; set; }

        public decimal PropertyPrice { get; set; }

        public int Rooms { get; set; }

        public int PropertyLivingArea { get; set; }
    }
}
