namespace RealEstateWebsite.Services.Data.Interfaces
{
    using System.Collections.Generic;

    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;
    using RealEstateWebsite.Web.ViewModels.Agencies;

    public interface IAgenciesService
    {
        IEnumerable<AllAgenciesServiceModel> GetAllAgencies();

        int GetEstateAgentId(string name);

        AgencyDetailsViewModel GetAgencyDetails(int agentId);
    }
}
