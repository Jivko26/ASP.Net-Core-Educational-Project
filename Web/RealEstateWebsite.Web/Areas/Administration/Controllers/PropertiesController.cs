namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data.Interfaces;
    using RealEstateWebsite.Web.ViewModels.Administration.Properties;

    public class PropertiesController : AdministrationController
    {
        private const string NonExistingDistrict = "District does not exist.";
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
                Districts = this.propertiesService.GetPropertyDistricts()
                            .ToList(),
                EstateAgents = this.propertiesService.GetPropertyEstateAgents(),
            });
        }

        [HttpPost]
        public IActionResult Add(AddPropertyFormModel property)
        {
            if (!this.districtsService.DistrictExists(property.PropertyFormModel.DistrictId))
            {
                this.ModelState.AddModelError(nameof(property.PropertyFormModel.DistrictId), NonExistingDistrict);
            }

            if (!this.ModelState.IsValid)
            {
                property.Types = this.propertiesService.GetPropertiesTypes();
                property.Districts = this.propertiesService.GetPropertyDistricts();
                property.EstateAgents = this.propertiesService.GetPropertyEstateAgents();

                return this.View(property);
            }

            this.propertiesService.CreateProperty(property.PropertyFormModel);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var property = this.propertiesService.GetPropertyById(id);

            var addPropertyForm = this.propertiesService.PreparePropertyFormModel(property);

            addPropertyForm.Districts = this.propertiesService.GetPropertyDistricts();
            addPropertyForm.EstateAgents = this.propertiesService.GetPropertyEstateAgents();
            addPropertyForm.Types = this.propertiesService.GetPropertiesTypes();

            return this.View(addPropertyForm);
        }

        [HttpPost]
        public IActionResult Edit(int id, AddPropertyFormModel property)
        {
            if (!this.districtsService.DistrictExists(property.PropertyFormModel.DistrictId))
            {
                this.ModelState.AddModelError(nameof(property.PropertyFormModel.DistrictId), NonExistingDistrict);
            }

            if (!this.ModelState.IsValid)
            {
                property.Types = this.propertiesService.GetPropertiesTypes();
                property.Districts = this.propertiesService.GetPropertyDistricts();
                property.EstateAgents = this.propertiesService.GetPropertyEstateAgents();

                return this.View(property);
            }

            this.propertiesService.Edit(id, property.PropertyFormModel);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Delete(int id)
        {
            var property = this.propertiesService.GetPropertyById(id);

            if (property == null)
            {
                return this.BadRequest();
            }

            this.propertiesService.SetIsDeletedToTrue(property);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
