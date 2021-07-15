namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;
    using RealEstateWebsite.Data.Models.Enum;

    public class Post : BaseDeletableModel<int>
    {

        [Required]
        public string PropertyPicture { get; set; }

        [Required]
        public TypeOfPost Type { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public int PropertyId { get; set; }

        public Property Property { get; set; }

    }
}
