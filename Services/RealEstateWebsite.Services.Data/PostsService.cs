namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Data.ServiceModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly ApplicationDbContext data;

        public PostsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void CreatePost(string title, string description, int estateAgentId, int propertyId)
        {
            var post = new Post
            {
                Title = title,
                Description = description,
                EstateAgentId = estateAgentId,
                PropertyId = propertyId,
            };

            this.data.Posts.Add(post);
            this.data.SaveChanges();
        }

        public IEnumerable<AllPostsServiceModel> GetAllPosts()
        {
            return null;
        }
    }
}
