namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Data.ServiceModels.Posts;

    public interface IPostsService
    {
        IEnumerable<AllPostsServiceModel> GetAllPosts();

        IEnumerable<AllPostsServiceModel> GetAllPostsByAgent(int agentId);

        IEnumerable<AllPostsServiceModel> GetAllPostsByDistrict(int propertyId);

        void CreatePost(string title, string description, int estateAgentId, int propertyId);

        Post GetPostById(int postId);

        void SetIsDeletedToTrue(Post post);
    }
}
