namespace RealEstateWebsite.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;

    using static RealEstateWebsite.Data.Common.DataConstants.District;

    public class District : BaseDeletableModel<int>
    {
        public District()
        {
            this.Properties = new List<Property>();
        }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
