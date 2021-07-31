namespace RealEstateWebsite.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        public IActionResult All()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(string smth)
        {
            return this.View();
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

        [Authorize]
        public IActionResult Delete(int postId)
        {
            return this.View();
        }
    }
}
