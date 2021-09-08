namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Data.ServiceModels.Posts;
    using RealEstateWebsite.Web.ViewModels.Home;

    public interface IPostsService
    {
        IEnumerable<AllPostsServiceModel> GetAllPosts();

        IEnumerable<AllPostsServiceModel> GetAllPostsByAgent(int agentId);

        IEnumerable<AllPostsServiceModel> GetAllPostsByDistrict(int districtId);

        IEnumerable<AllPostsServiceModel> GetAllPostsBySearch(IndexSearchViewModel searchTerms);

        PostDetailsModel GetPostDetails(int postId);

        void EditPost(Post post, string title, string description);

        void CreatePost(string title, string description, int estateAgentId, int propertyId);

        Post GetPostById(int postId);

        void SetIsDeletedToTrue(Post post);
    }
}
