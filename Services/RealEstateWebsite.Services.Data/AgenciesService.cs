namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Services.Data.Interfaces;
    using RealEstateWebsite.Services.Data.ServiceModels.Agencies;
    using RealEstateWebsite.Web.ViewModels.Agencies;

    public class AgenciesService : IAgenciesService
    {
        private readonly ApplicationDbContext data;
        private Dictionary<string, string> agenciesPictures = new Dictionary<string, string>
        {
            ["Rotterdam Apartments"] = "https://media.pararius.nl/image/EA0000003000/EA0000003052/image/jpeg/120x260/Rotterdam_ApartmentsRotterdamParklaan-c214_1.jpg",
            ["ViaDaan"] = "https://media.pararius.nl/image/EA0000013000/EA0000013301/image/jpeg/120x260/ViaDaanEindhovenFellenoord-b24b_1.jpg",
            ["The Hague Real Estate Services"] = "https://media.pararius.nl/image/EA0000004000/EA0000004546/image/jpeg/120x260/The_Hague_Real_Estate_ServicesDenHaagKon-545e_1.jpg",
            ["Riva Rentals"] = "https://media.pararius.nl/image/EA0000004000/EA0000004643/image/jpeg/120x260/Riva_RentalsRotterdamOostzeedijkBeneden-075f_1.jpg",
            ["Amsterdam Housing"] = "https://media.pararius.nl/image/EA0000000000/EA0000000130/image/jpeg/120x260/AmsterdamHousingAmsterdamSlingerbeekstra-3855_1.jpg",
            ["Rotsvast Eindhoven"] = "https://media.pararius.nl/image/EA0000000000/EA0000000085/image/jpeg/120x260/Rotsvast_EindhovenEindhovenWillemstraat-7add_1.jpg",
            ["Homeland Real Estate"] = "https://media.pararius.nl/image/EA0000013000/EA0000013452/image/jpeg/120x260/Homeland_Real_EstateDenHaagValeriusstraa-4332_1.jpg",
            ["Tweelwonen.nl Leiden"] = "https://media.pararius.nl/image/EA0000003000/EA0000003157/image/jpeg/120x260/TweelwonennlLeidenOudeHerengracht-b49d_1.jpg",
            ["HB Housing"] = "https://media.pararius.nl/image/EA0000000000/EA0000000532/image/jpeg/120x260/HB_Housing_AmsterdamSloterkade-cc42_1.jpg",
            ["BenHousing"] = "https://media.pararius.nl/image/EA0000000000/EA0000000157/image/jpeg/120x260/BenHousingRotterdamJonkerFransstraat-e6de_1.jpg",
        };

        public AgenciesService(ApplicationDbContext data)
            => this.data = data;

        public AgencyDetailsViewModel GetAgencyDetails(int agentId)
        {
            var agency = this.data.RealEstateAgents
            .Where(a => a.Id == agentId)
            .Select(a => new AgencyDetailsViewModel
            {
                AgentId = a.Id,
                Name = a.Name,
                Description = a.Description,
                PhoneNumber = a.Telephone,
                Address = a.OfficeLocation,
                Email = a.ContactEmail,
                WebSiteUrl = a.WebSiteUrl,
            })
            .FirstOrDefault();

            agency.AgenciesPictures = this.agenciesPictures;

            return agency;
        }

        public IEnumerable<AllAgenciesServiceModel> GetAllAgencies()
            => this.data.RealEstateAgents
                .Where(a => !a.IsDeleted)
                .Select(a => new AllAgenciesServiceModel
                {
                    AgentId = a.Id,
                    Name = a.Name,
                    Description = a.Description,
                    PropertiesCount = a.Properties.Count(),
                })
                .OrderByDescending(ea => ea.PropertiesCount)
                .ToList();

        public int GetEstateAgentId(string name)
            => this.data.RealEstateAgents
                 .Where(e => e.Name == name)
                 .Select(e => e.Id)
                 .FirstOrDefault();
    }
}
