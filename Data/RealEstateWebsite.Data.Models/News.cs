namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    public class News : BaseDeletableModel<int>
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
