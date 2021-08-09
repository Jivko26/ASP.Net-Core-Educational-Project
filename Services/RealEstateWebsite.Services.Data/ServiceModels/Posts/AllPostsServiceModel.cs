namespace RealEstateWebsite.Services.Data.ServiceModels.Posts
{
    using System;

    using RealEstateWebsite.Data.Models;

    public class AllPostsServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal PropertyPrice { get; set; }

        public string PropertyEstateAgent { get; set; }

        public int PropertyId { get; set; }

        public int EstateAgentId { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
