namespace RealEstateWebsite.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Web.ViewModels.Administration.Properties;

    public class IndexSearchViewModel
    {
        [Display(Name = "City")]
        public int DistrictId { get; set; }

        [Display(Name = "Type of Property")]
        public PropertyType Type { get; set; }

        [Display(Name = "Max Price")]
        public decimal MaxPrice { get; set; }

        public IEnumerable<PropertysDistrictViewModel> Districts { get; set; }

        public IEnumerable<PropertyType> Types { get; set; }
    }
}
