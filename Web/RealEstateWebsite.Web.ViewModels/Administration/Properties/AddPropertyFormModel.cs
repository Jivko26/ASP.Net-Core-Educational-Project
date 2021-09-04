namespace RealEstateWebsite.Web.ViewModels.Administration.Properties
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models.Enum;

    public class AddPropertyFormModel
    {
        public PropertyFormModel PropertyFormModel { get; set; }

        public IEnumerable<PropertysDistrictViewModel> Districts { get; set; }

        public IEnumerable<PropertysEstateAgentViewModel> EstateAgents { get; set; }

        public IEnumerable<PropertyType> Types { get; set; }
    }
}
