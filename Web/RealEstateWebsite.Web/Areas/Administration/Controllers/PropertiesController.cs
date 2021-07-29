namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;

    public class PropertiesController : AdministrationController
    {

        private readonly IPropertiesService propertiesService;

        public PropertiesController(IPropertiesService propertiesService)
            => this.propertiesService = propertiesService;

        public IActionResult All()
        {
            var properties = this.propertiesService.GetAllProperties();

            return this.View(properties);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        public IActionResult Edit(int propertyId)
        {
            return this.View();
        }

        public IActionResult Delete(int propertyId)
        {
            return this.View();
        }
    }
}
