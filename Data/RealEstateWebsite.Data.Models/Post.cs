namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    using static RealEstateWebsite.Data.Common.DataConstants.Post;

    public class Post : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(TitleMaxLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; }

        public int EstateAgentId { get; set; }

        public EstateAgent EstateAgent { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

    }
}
