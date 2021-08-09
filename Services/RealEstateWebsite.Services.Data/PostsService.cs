namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
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
            => this.data.Posts
                    .Where(p => !p.IsDeleted)
                    .Select(p => new AllPostsServiceModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        CreatedOn = p.CreatedOn,
                        PropertyEstateAgent = p.EstateAgent.Name,
                        PropertyPrice = p.Property.Price,
                    })
                    .OrderByDescending(ap => ap.CreatedOn)
                    .ToList();

        public Post GetPostById(int postId)
            => this.data.Posts
                    .FirstOrDefault(p => p.Id == postId);

        public void SetIsDeletedToTrue(Post post)
        {
            post.IsDeleted = true;

            this.data.SaveChanges();
        }

    }
}
