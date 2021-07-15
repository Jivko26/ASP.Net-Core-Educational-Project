namespace RealEstateWebsite.Data.Models
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    public class EstateAgent : BaseDeletableModel<int>
    {
        public EstateAgent()
        {
            this.Properties = new List<Property>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string ContactEmail { get; set; }

        [MaxLength(10)]
        public string Telephone { get; set; }

        [Required]
        public string WebSiteUrl { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        [Required]
        public string OfficeLocation { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
