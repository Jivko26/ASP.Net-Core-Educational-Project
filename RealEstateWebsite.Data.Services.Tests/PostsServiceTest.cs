namespace RealEstateWebsite.Data.Services.Tests
{
    using Xunit;
    using Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using System.Linq;

    public class PostsServiceTest
    {
        [Theory]
        [InlineData("Test", "Testing", 1, 1)]
        public void CreatePostShouldWorkCorrectly(string title, string description, int estateAgentId, int propertyId)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            postService.CreatePost(title, description, estateAgentId, propertyId);

            var result = data.Posts.Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("Test", "Testing", 1, 1)]
        public void EditPostShouldWorkCorrectly(string title, string description, int estateAgentId, int propertyId)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            postService.CreatePost(title, description, estateAgentId, propertyId);

            var post = data.Posts.First();

            postService.EditPost(post, "Edited", "Editing");

            var result = data.Posts.First();

            //Assert

            Assert.Equal("Edited", result.Title);
            Assert.Equal("Editing", result.Description);
        }

        [Fact]
        public void GetAllPostsShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            });

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,

            });

            data.SaveChanges();

            var result = postService.GetAllPosts().Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAllPostsByAgentShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            var estateAgent = new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            };

            data.RealEstateAgents.Add(estateAgent);

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,
                EstateAgent = estateAgent,
            });

            data.SaveChanges();

            var result = postService.GetAllPostsByAgent(estateAgent.Id).Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetAllPostsByDistrictShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            data.Districts.Add(new District
            {
                Name = "Santoss"
            });

            var estateAgent = new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            };

            data.RealEstateAgents.Add(estateAgent);

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
                DistcrictId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,
                EstateAgent = estateAgent,
            });

            data.SaveChanges();

            var result = postService.GetAllPostsByDistrict(1).Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetPostByIdShouldReturnTheCorrectPost()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            });

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,
            });

            data.SaveChanges();

            var result = postService.GetPostById(1);

            //Assert

            Assert.Equal("Title", result.Title);
        }

        [Fact]
        public void GetPostDetailsShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            });

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                LivingArea = 12,
                Floor = 0,
                TotalFloors = 2,
                Rooms = 1,
                Year = 1300,
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,
            });

            data.SaveChanges();

            var result = postService.GetPostDetails(1);

            //Assert

            Assert.Equal("Title", result.Title);
            Assert.Equal("SANTOS", result.PropertyEstateAgentName);
            Assert.Equal(12, result.PropertyLivingArea);
        }

        [Fact]
        public void SetIsDeletedToTrueShouldWorkCorre()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var postService = new PostsService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            });

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                EstateAgentId = 1,
            });

            data.Posts.Add(new Post
            {
                Title = "Title",
                Description = "Description",
                EstateAgentId = 1,
                PropertyId = 1,
            });

            data.SaveChanges();

            var post = postService.GetPostById(1);

            postService.SetIsDeletedToTrue(post);

            //Assert

            Assert.True(post.IsDeleted);
        }
    }
}
