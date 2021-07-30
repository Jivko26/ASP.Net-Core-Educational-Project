﻿namespace RealEstateWebsite.Web.Areas.Administration.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Models.Enum;

    using static RealEstateWebsite.Data.Common.DataConstants.Property;

    public class AddPropertyFormModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(InteriorMaxLenght, MinimumLength = InteriorMinLenght)]
        public string Interior { get; set; }

        [Required]
        [StringLength(AddressMaxLenght, MinimumLength = AddressMinLenght)]
        public string Address { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string PictureUrl { get; set; }

        [Display(Name = "Living Area")]
        [Range(MinLivingArea, MaxLivingArea)]
        public int LivingArea { get; set; }

        [Range(MinRooms, MaxRooms)]
        public int Rooms { get; set; }

        [Range(MinFloors, MaxFloors)]
        public int Floor { get; set; }

        [Range(MinFloors, MaxFloors)]
        public int TotalFloors { get; set; }

        [Display(Name = "Year (Not Mandatory)")]
        [Range(MinYear, MaxYear)]
        public int? Year { get; set; }

        [Range(MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "District")]
        public int DistrictId { get; set; }

        [Required]
        [Display(Name = "Estate Agent")]
        public int EstateAgentId { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public IEnumerable<PropertysDistrictViewModel> Districts { get; set; }

        public IEnumerable<PropertysEstateAgentViewModel> EstateAgents { get; set; }

        public IEnumerable<PropertyType> Types { get; set; }
    }
}
