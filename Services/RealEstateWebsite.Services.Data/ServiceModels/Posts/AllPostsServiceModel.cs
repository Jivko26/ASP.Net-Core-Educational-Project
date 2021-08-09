namespace RealEstateWebsite.Services.Data.ServiceModels.Posts
{
    using System;

    public class AllPostsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PropertyPrice { get; set; }

        public string PropertyEstateAgent { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
