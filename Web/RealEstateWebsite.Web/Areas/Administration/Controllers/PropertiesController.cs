namespace RealEstateWebsite.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Data.Models.Enum;
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
                Districts = this.GetPropertyDistricts()
                            .ToList(),
                EstateAgents = this.GetPropertyEstateAgents(),
            });
        }

        [HttpPost]
        public IActionResult Add(AddPropertyFormModel property)
        {

            if (!this.districtsService.DistrictExists(property.DistrictId))
            {
                this.ModelState.AddModelError(nameof(property.DistrictId), "District does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                property.Types = this.propertiesService.GetPropertiesTypes();
                property.Districts = this.GetPropertyDistricts();
                property.EstateAgents = this.GetPropertyEstateAgents();

                return this.View(property);
            }

            this.propertiesService.CreateProperty(
                property.Id,
                property.Interior,
                property.Address,
                property.PictureUrl,
                property.LivingArea,
                property.Rooms,
                property.Floor,
                property.TotalFloors,
                property.Price,
                property.DistrictId,
                property.EstateAgentId,
                property.Type,
                property.Year);

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }

        public IActionResult Edit(int id)
        {

            var property = this.propertiesService.GetPropertyById(id);

            var addPropertyForm = this.PreparePropertyFormModel(
                property.Id,
                property.Interior,
                property.Address,
                property.PictureUrl,
                property.LivingArea,
                property.Rooms,
                property.Floor,
                property.TotalFloors,
                property.Price,
                property.DistcrictId,
                property.EstateAgentId,
                property.Type,
                property.Year);

            addPropertyForm.Districts = this.GetPropertyDistricts();
            addPropertyForm.EstateAgents = this.GetPropertyEstateAgents();
            addPropertyForm.Types = this.propertiesService.GetPropertiesTypes();

            return this.View(addPropertyForm);
        }

        [HttpPost]
        public IActionResult Edit(int id, AddPropertyFormModel property)
        {
            // TODO: Extract the validation for Add and Edit method in private methods or services plus add more validations

            if (!this.districtsService.DistrictExists(property.DistrictId))
            {
                this.ModelState.AddModelError(nameof(property.DistrictId), "District does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                property.Types = this.propertiesService.GetPropertiesTypes();
                property.Districts = this.GetPropertyDistricts();
                property.EstateAgents = this.GetPropertyEstateAgents();

                return this.View(property);
            }

            this.propertiesService.Edit(
                property.Id,
                property.Interior,
                property.Address,
                property.PictureUrl,
                property.LivingArea,
                property.Rooms,
                property.Floor,
                property.TotalFloors,
                property.Price,
                property.DistrictId,
                property.EstateAgentId,
                property.Type,
                property.Year);

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

        private AddPropertyFormModel PreparePropertyFormModel(
            int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            return new AddPropertyFormModel
            {
                Id = id,
                Interior = interior,
                Address = address,
                PictureUrl = pictureUrl,
                LivingArea = livingArea,
                Rooms = rooms,
                Floor = floor,
                TotalFloors = totalFloors,
                Price = price,
                DistrictId = districtId,
                EstateAgentId = estateAgentId,
                Type = propertyType,
                Year = year,
            };
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
