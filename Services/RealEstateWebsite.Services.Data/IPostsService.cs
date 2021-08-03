﻿namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.Posts;

    public interface IPostsService
    {
        IEnumerable<AllPostsServiceModel> GetAllPosts();
    }
}
