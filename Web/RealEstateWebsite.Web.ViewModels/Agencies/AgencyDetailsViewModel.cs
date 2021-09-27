namespace RealEstateWebsite.Web.ViewModels.Agencies
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Services.Mapping;

    public class AgencyDetailsViewModel : IMapFrom<EstateAgent>
    {
        public int AgentId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string WebSiteUrl { get; set; }

        public Dictionary<string, string> AgenciesPictures { get; set; }
    }
}
