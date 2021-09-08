namespace RealEstateWebsite.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using RealEstateWebsite.Data.Models;

    internal class RealEstateAgenciesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (dbContext.RealEstateAgents.Any())
            {
                return;
            }

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Rotterdam Apartments",
                WebSiteUrl = "https://rotterdamapartments.com/en",
                ContactEmail = "info@rotterdamapartments.com",
                Telephone = "+31104122221",
                Description = "Welcome to the estate agent for Rotterdam's most interesting properties. Est. In 2009, our office has been exceeding expectations and continuously meeting the demands of an increasingly dynamic housing market.",
                OfficeLocation = "Schiedamsedijk 200 3011 EP Rotterdam",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "ViaDaan",
                WebSiteUrl = "https://www.viadaan.nl/",
                ContactEmail = "info@ViaDaan.nl",
                Description = "ViaDaan, rent responsibly.ViaDaan stands for mediation between tenants and landlords in the private housing market.",
                OfficeLocation = "Fellenoord 39, 5612 AA Eindhoven, Netherlands",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Riva Rentals",
                WebSiteUrl = "https://www.rivarentals.com/",
                ContactEmail = "info@rivarentals.com",
                Telephone = "+31102361795",
                Description = "Our rental agents are highly trained. They are knowledgeable, energetic and highly committed. We know the inventory inside out and work with the best landlords an other agencies in the city.",
                OfficeLocation = "Oostzeedijk Beneden 193 a3061 VS Rotterdam",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "The Hague Real Estate Services",
                WebSiteUrl = "https://www.thehaguerealestate.nl/",
                ContactEmail = "info@thres.nl",
                Telephone = "+31702141077",
                Description = "The Hague Real Estate Services is a dynamic organization staffed by driven professionals who are among the best in their various fields. Our service and offering combines exclusive and top-quality real estate with a personal and customer-focused sales strategy.",
                OfficeLocation = "Koninginnegracht 60 2514 AE - Den Haag",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Amsterdam Housing",
                WebSiteUrl = "https://www.amsterdamhousing.com/",
                ContactEmail = "info@amsterdamhousing.com",
                Telephone = "+31(0)206717266",
                Description = "Amsterdam Housing is a quality-oriented real estate agency for housing in Amsterdam, Amstelveen, The Hague, Wassenaar, Haarlem, ‘t Gooi and nearby towns. We specialize in helping employees from overseas to quickly find appropriate housing in the Netherlands.",
                OfficeLocation = "Slingerbeekstraat 29 1078 BH Amsterdam ",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Rotsvast Eindhoven",
                WebSiteUrl = "https://www.rotsvast.nl/rotsvast-eindhoven/",
                ContactEmail = "eindhoven@rotsvast.nl",
                Telephone = "+31(0)40-2440244",
                Description = "Rotsvast has been THE SPECIALIST in property rentals for over 30 years, with activities like property management and long- and short-stay rent.",
                OfficeLocation = "Willemstraat 14 5611 HD Eindhoven",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Homeland Real Estate",
                WebSiteUrl = "https://www.homelandrealestate.nl/",
                ContactEmail = "info@homelandmail.nl",
                Telephone = "+31708200920",
                Description = "Our search engine: finding the right property in time for the right price.",
                OfficeLocation = "Valeriusstraat 16 2517 HR DEN HAAG",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "Tweelwonen.nl Leiden",
                WebSiteUrl = "https://www.tweelwonen.nl/",
                ContactEmail = "leiden@2L.nl",
                Telephone = "+31715246878",
                Description = "Tweelwonen is the most reputable brokerage office in Leiden and surroundings since 2003 and has experience in all areas of leasing and rental of living accommodations.",
                OfficeLocation = "Willem de Zwijgerlaan 2 L2316 GB Leiden",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "HB Housing",
                WebSiteUrl = "https://www.hbhousing.nl/",
                ContactEmail = "info@hbhousing.nl",
                Telephone = "+31206170379",
                Description = "We have been active on the housing market for many years and know the market thoroughly. That is why we are a valuable partner for renting as well as letting. Thanks to reliable contacts in our network, we can always find suitable housing or a tenant for you.",
                OfficeLocation = "Sloterkade 182, 1059EB Amsterdam",
            });

            await dbContext.RealEstateAgents.AddAsync(new EstateAgent
            {
                Name = "BenHousing",
                WebSiteUrl = "https://www.benhousing.nl/",
                ContactEmail = "info@benhousing.nl",
                Telephone = "+31102040661",
                Description = "BenHousing is the specialist in the field of rental brokerage of apartments in Rotterdam. In addition, we manage professionally property.",
                OfficeLocation = "onker Fransstraat 94a 3031 AW Rotterdam",
            });
        }
    }
}
