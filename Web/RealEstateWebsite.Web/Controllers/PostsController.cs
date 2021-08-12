namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Common;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Web.ViewModels.Posts;

    public class PostsController : Controller
    {
        private readonly IPropertiesService propertiesService;
        private readonly IAgenciesService agenciesService;
        private readonly IPostsService postsService;

        public PostsController(
            IPropertiesService propertiesService,
            IAgenciesService agenciesService,
            IPostsService postsService)
        {
            this.propertiesService = propertiesService;
            this.agenciesService = agenciesService;
            this.postsService = postsService;
        }

        public IActionResult All()
        {
            var posts = this.postsService.GetAllPosts();

            return this.View(posts);
        }

        public IActionResult ByAgent(int agentId)
        {
            var posts = this.postsService.GetAllPostsByAgent(agentId);

            return this.View(posts);
        }

        public IActionResult ByDistrict(int id)
        {

            var posts = this.postsService.GetAllPostsByDistrict(id);

            return this.View(posts);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Create(int propertyId)
        {
            var property = this.propertiesService.GetPropertyById(propertyId);

            return this.View(this.CreatePostFormModel(property));

        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Create(int propertyId, CreatePostFormModel postFormModel)
        {
            var estateAgentId = this.agenciesService.GetEstateAgentId(postFormModel.EstateAgent);

            if (!this.ModelState.IsValid)
            {
                return this.View(postFormModel);
            }

            this.postsService.CreatePost(postFormModel.Title, postFormModel.Description, estateAgentId, propertyId);
            return this.RedirectToAction(nameof(this.All));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int postId)
        {
            var post = this.postsService.GetPostById(postId);

            return this.View(this.PrepareEditPostModel(post, post.Property));
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        public IActionResult Edit(int postId, CreatePostFormModel postFormModel)
        {
            var post = this.postsService.GetPostById(postId);

            if (!this.ModelState.IsValid)
            {
                return this.View(postFormModel);
            }

            this.postsService.EditPost(post, postFormModel.Title, postFormModel.Description);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int postId)
        {
            var detailsModel = this.postsService.GetPostDetails(postId);

            return this.View(detailsModel);
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Delete(int postId)
        {
            var post = this.postsService.GetPostById(postId);

            if (post == null)
            {
                return this.BadRequest();
            }

            this.postsService.SetIsDeletedToTrue(post);

            return this.RedirectToAction(nameof(this.All));
        }

        private CreatePostFormModel PrepareEditPostModel(Post post, Property property)
        {
            return new CreatePostFormModel
            {
                Title = post.Title,
                Description = post.Description,
                PropertyInterior = property.Interior,
                PropertyAddress = property.Address,
                PropertyPictureUrl = property.PictureUrl,
                PropertyFloor = property.Floor,
                PropertyTotalFloors = property.TotalFloors,
                PropertyLivingArea = property.LivingArea,
                PropertyPrice = property.Price,
                PropertyRooms = property.Rooms,
                PropertyType = property.Type.ToString(),
                PropertyYear = property.Year,
                EstateAgent = property.EstateAgent.Name,
            };
        }

        private CreatePostFormModel CreatePostFormModel(Property property)
        {
            return new CreatePostFormModel
            {
                PropertyInterior = property.Interior,
                PropertyAddress = property.Address,
                PropertyPictureUrl = property.PictureUrl,
                PropertyFloor = property.Floor,
                PropertyTotalFloors = property.TotalFloors,
                PropertyLivingArea = property.LivingArea,
                PropertyPrice = property.Price,
                PropertyRooms = property.Rooms,
                PropertyType = property.Type.ToString(),
                PropertyYear = property.Year,
                EstateAgent = property.EstateAgent.Name,
            };
        }
    }
}
