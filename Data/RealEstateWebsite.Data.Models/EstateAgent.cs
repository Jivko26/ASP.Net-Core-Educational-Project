namespace RealEstateWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    using static RealEstateWebsite.Data.Common.DataConstants.EstateAgent;

    public class EstateAgent : BaseDeletableModel<int>
    {
        public EstateAgent()
        {
            this.Properties = new List<Property>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(EmailMaxLenght)]
        public string ContactEmail { get; set; }

        [MaxLength(TelephoneMaxLenght)]
        public string Telephone { get; set; }

        [Required]
        public string WebSiteUrl { get; set; }

        public string Description { get; set; }

        public string Picture { get; set; }

        [Required]
        [MaxLength(OfficeLocationMaxLenght)]
        public string OfficeLocation { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
