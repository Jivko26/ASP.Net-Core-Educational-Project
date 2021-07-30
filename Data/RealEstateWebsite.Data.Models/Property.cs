namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;
    using RealEstateWebsite.Data.Models.Enum;

    using static RealEstateWebsite.Data.Common.DataConstants.Property;

    public class Property : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(InteriorMaxLenght)]
        public string Interior { get; set; }

        [Required]
        [MaxLength(AddressMaxLenght)]
        public string Address { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public int LivingArea { get; set; }

        public int Rooms { get; set; }

        public int Floor { get; set; }

        public int TotalFloors { get; set; }

        public int? Year { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public decimal Price { get; set; }

        public int DistcrictId { get; set; }

        public District District { get; set; }

        public int EstateAgentId { get; set; }

        public EstateAgent EstateAgent { get; set; }

    }
}
