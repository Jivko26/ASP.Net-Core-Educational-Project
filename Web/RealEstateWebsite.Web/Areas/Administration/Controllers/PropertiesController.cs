namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Services.Data;
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
                Districts = this.GetPropertyDistricts()
                            .ToList(),
                EstateAgents = this.GetPropertyEstateAgents(),
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
                property.Districts = this.GetPropertyDistricts();
                property.EstateAgents = this.GetPropertyEstateAgents();

                return this.View(property);
            }

            this.propertiesService.CreateProperty(property.PropertyFormModel);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Edit(int id)
        {
            var property = this.propertiesService.GetPropertyById(id);

            var addPropertyForm = this.propertiesService.PreparePropertyFormModel(property);

            addPropertyForm.Districts = this.GetPropertyDistricts();
            addPropertyForm.EstateAgents = this.GetPropertyEstateAgents();
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
                property.Districts = this.GetPropertyDistricts();
                property.EstateAgents = this.GetPropertyEstateAgents();

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

        private IEnumerable<PropertysDistrictViewModel> GetPropertyDistricts()
            => this.districtsService.GetAllDistricts()
                            .Select(d => new PropertysDistrictViewModel
                            {
                                Id = d.Id,
                                Name = d.Name,
                            }).ToList();

        private IEnumerable<PropertysEstateAgentViewModel> GetPropertyEstateAgents()
           => this.agenciesService.GetAllAgencies()
                            .Select(a => new PropertysEstateAgentViewModel
                            {
                                Id = a.AgentId,
                                Name = a.Name,
                            })
                            .ToList();
    }

}
