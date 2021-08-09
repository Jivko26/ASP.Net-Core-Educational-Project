namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Web.ViewModels.Posts;
    using RealEstateWebsite.Data.Models;

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

        //[Authorize]
        //public IActionResult Edit(int id)
        //{

        //    var property = this.propertiesService.GetPropertyById(id);

        //    var addPropertyForm = this.PreparePropertyFormModel(
        //        property.Id,
        //        property.Interior,
        //        property.Address,
        //        property.PictureUrl,
        //        property.LivingArea,
        //        property.Rooms,
        //        property.Floor,
        //        property.TotalFloors,
        //        property.Price,
        //        property.DistcrictId,
        //        property.EstateAgentId,
        //        property.Type,
        //        property.Year);

        //    addPropertyForm.Districts = this.GetPropertyDistricts();
        //    addPropertyForm.EstateAgents = this.GetPropertyEstateAgents();
        //    addPropertyForm.Types = this.propertiesService.GetPropertiesTypes();

        //    return this.View(addPropertyForm);
        //}

        //[Authorize]
        //[HttpPost]
        //public IActionResult Edit(int id, AddPropertyFormModel property)
        //{
        //    // TODO: Extract the validation for Add and Edit method in private methods or services plus add more validations

        //    if (!this.districtsService.DistrictExists(property.DistrictId))
        //    {
        //        this.ModelState.AddModelError(nameof(property.DistrictId), "District does not exist.");
        //    }

        //    if (!this.ModelState.IsValid)
        //    {
        //        property.Types = this.propertiesService.GetPropertiesTypes();
        //        property.Districts = this.GetPropertyDistricts();
        //        property.EstateAgents = this.GetPropertyEstateAgents();

        //        return this.View(property);
        //    }

        //    this.propertiesService.Edit(
        //        property.Id,
        //        property.Interior,
        //        property.Address,
        //        property.PictureUrl,
        //        property.LivingArea,
        //        property.Rooms,
        //        property.Floor,
        //        property.TotalFloors,
        //        property.Price,
        //        property.DistrictId,
        //        property.EstateAgentId,
        //        property.Type,
        //        property.Year);

        //    return this.RedirectToAction(nameof(this.All));
        //}

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
