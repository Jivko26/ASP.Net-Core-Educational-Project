namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
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

        public void EditPost(Post post, string title, string description)
        {
            post.Title = title;
            post.Description = description;

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
                        PropertyId = p.Property.Id,
                        EstateAgentId = p.EstateAgentId,
                    })
                    .OrderByDescending(ap => ap.CreatedOn)
                    .ToList();

        public IEnumerable<AllPostsServiceModel> GetAllPostsByAgent(int agentId)
            => this.data.Posts
                    .Where(p => !p.IsDeleted && p.EstateAgent.Id == agentId)
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

        public IEnumerable<AllPostsServiceModel> GetAllPostsByDistrict(int propertyId)
            => this.data.Posts
                    .Select(p => new AllPostsServiceModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                        CreatedOn = p.CreatedOn,
                        PropertyEstateAgent = p.EstateAgent.Name,
                        PropertyPrice = p.Property.Price,
                        PropertyId = p.Property.Id,
                    })
                    .Where(ap => ap.PropertyId == propertyId)
                    .OrderByDescending(ap => ap.CreatedOn)
                    .ToList();

        public Post GetPostById(int postId)
            => this.data.Posts
                    .Include(p => p.Property)
                    .ThenInclude(pr => pr.EstateAgent)
                    .FirstOrDefault(p => p.Id == postId);

        public PostDetailsModel GetPostDetails(int postId)
            => this.data.Posts
            .Where(p => p.Id == postId)
            .Include(p => p.Property)
            .ThenInclude(pr => pr.EstateAgent)
            .Select(p => new PostDetailsModel
            {
                Title = p.Title,
                Description = p.Description,
                PropertyPictureUrl = p.Property.PictureUrl,
                PropertyInterior = p.Property.Interior,
                PropertyLivingArea = p.Property.LivingArea,
                PropertyPrice = p.Property.Price,
                PropertyRooms = p.Property.Rooms,
                PropertyFloor = p.Property.Floor,
                PropertyTotalFloors = p.Property.TotalFloors,
                PropertyYear = p.Property.Year,
                PropertyEstateAgentId = p.Property.EstateAgent.Id,
                PropertyEstateAgentName = p.Property.EstateAgent.Name,
                PropertyEstateAgentPhone = p.Property.EstateAgent.Telephone,
                PropertyEstateAgentWebsite = p.Property.EstateAgent.WebSiteUrl,
            })
            .FirstOrDefault();

        public void SetIsDeletedToTrue(Post post)
        {
            post.IsDeleted = true;

            this.data.SaveChanges();
        }

    }
}
