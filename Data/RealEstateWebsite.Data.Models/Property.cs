namespace RealEstateWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;
    using RealEstateWebsite.Data.Models.Enum;

    public class Property : BaseDeletableModel<int>
    {

        public int Size { get; set; }

        public int YardSize { get; set; }

        public int Floor { get; set; }

        public int TotalFloors { get; set; }

        public int Year { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        [Required]
        public BuildingType BuildingType { get; set; }

        public decimal Price { get; set; }

        //public int DistcrictId { get; set; }

        //public District District { get; set; }

        //public int EstateAgentId { get; set; }

        //public EstateAgent EstateAgent { get; set; }

        //public ICollection<Tag> PropertyTags { get; set; }
    }
}
