namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {

        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }
    }
}
