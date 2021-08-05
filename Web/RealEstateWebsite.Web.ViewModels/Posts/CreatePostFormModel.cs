namespace RealEstateWebsite.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using static RealEstateWebsite.Data.Common.DataConstants.Post;
    using static RealEstateWebsite.Data.Common.DataConstants.Property;

    public class CreatePostFormModel
    {
        [Required]
        [StringLength(TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        [Required]
        [StringLength(InteriorMaxLenght, MinimumLength = InteriorMinLenght)]
        public string PropertyInterior { get; set; }

        [Required]
        [StringLength(AddressMaxLenght, MinimumLength = AddressMinLenght)]
        public string PropertyAddress { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string PropertyPictureUrl { get; set; }

        [Display(Name = "Living Area")]
        [Range(MinLivingArea, MaxLivingArea)]
        public int PropertyLivingArea { get; set; }

        [Range(MinRooms, MaxRooms)]
        public int PropertyRooms { get; set; }

        [Range(MinFloors, MaxFloors)]
        public int PropertyFloor { get; set; }

        [Range(MinFloors, MaxFloors)]
        public int PropertyTotalFloors { get; set; }

        [Display(Name = "Year of construction (Not Mandatory)")]
        [Range(MinYear, MaxYear)]
        public int? PropertyYear { get; set; }

        [Display(Name = "Price per month in euro")]
        [Range(MinPrice, MaxPrice)]
        public decimal PropertyPrice { get; set; }

        [Required]
        public string PropertyType { get; set; }

        [Required]
        public string EstateAgent { get; set; }
    }
}
