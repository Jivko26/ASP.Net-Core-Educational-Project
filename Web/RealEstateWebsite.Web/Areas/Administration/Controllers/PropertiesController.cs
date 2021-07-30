namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Web.Areas.Administration.Models;

    public class PropertiesController : AdministrationController
    {

        private readonly IPropertiesService propertiesService;
        private readonly IDistrictsService districtsService;
        private readonly IAgenciesService agenciesService;

        public PropertiesController(
            IPropertiesService propertiesService,
            IDistrictsService districtsService,
            IAgenciesService agenciesService)
        {
            this.propertiesService = propertiesService;
            this.districtsService = districtsService;
            this.agenciesService = agenciesService;
        }

        public IActionResult All()
        {
            var properties = this.propertiesService.GetAllProperties();

            return this.View(properties);
        }

        public IActionResult Add()
        {

            return this.View(new AddPropertyFormModel
            {
                Types = this.propertiesService.GetPropertiesTypes(),
                Districts = this.districtsService.GetAllDistricts()
                            .Select(d => new PropertysDistrictViewModel
                            {
                                Id = d.Id,
                                Name = d.Name,
                            })
                            .ToList(),
                EstateAgents = this.agenciesService.GetAllAgencies()
                            .Select(a => new PropertysEstateAgentViewModel
                            {
                                Id = a.AgentId,
                                Name = a.Name,
                            })
                            .ToList(),
            });
        }

        //[HttpPost]
        //public IActionResult Add(AddPropertyFormModel property)
        //{

        //    if (!this.cars.CategoryExists(car.CategoryId))
        //    {
        //        this.ModelState.AddModelError(nameof(car.CategoryId), "Category does not exist.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        car.Categories = this.cars.AllCategories();

        //        return View(car);
        //    }

        //    this.cars.Create(
        //        car.Brand,
        //        car.Model,
        //        car.Description,
        //        car.ImageUrl,
        //        car.Year,
        //        car.CategoryId,
        //        dealerId);

        //    return RedirectToAction(nameof(All));
        //}

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
