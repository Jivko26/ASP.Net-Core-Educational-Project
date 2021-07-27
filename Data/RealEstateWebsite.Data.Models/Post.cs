namespace RealEstateWebsite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using RealEstateWebsite.Data.Common.Models;
    using RealEstateWebsite.Data.Models.Enum;

    public class Post : BaseDeletableModel<int>
    {

        public string Description { get; set; }

        public int EstateAgentId { get; set; }

        public EstateAgent EstateAgent { get; set; }

        public int PropertyId { get; set; }

        public Property Property { get; set; }

    }
}
