namespace RealEstateWebsite.Data.Services.Tests
{
    using Xunit;
    using Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Data.Models;
    using System.Linq;

    public class AgenciesServiceTest
    {
        [Fact]
        public void GetAllAgenciesShouldReturnAllAgenciesCount()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var agenciesService = new AgenciesService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "Test",
                ContactEmail = "test@test.com",
                WebSiteUrl = "www.test.com",
                OfficeLocation = "somewhere test"
            });

            data.SaveChanges();

            var result = agenciesService.GetAllAgencies().Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetEstateAgentShouldReturnTheCorrectEstateAgent()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var agenciesService = new AgenciesService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "Test",
                ContactEmail = "test@test.com",
                WebSiteUrl = "www.test.com",
                OfficeLocation = "somewhere test"
            });

            data.SaveChanges();

            var result = agenciesService.GetEstateAgentId("Test");

            //Assert

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetEstateAgentShouldReturnTheNullWhenEstateAgentDoesNotExist()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var agenciesService = new AgenciesService(data);

            //Act

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "Test",
                ContactEmail = "test@test.com",
                WebSiteUrl = "www.test.com",
                OfficeLocation = "somewhere test"
            });

            data.SaveChanges();

            var result = agenciesService.GetEstateAgentId("Test1");

            //Assert

            Assert.Equal(0, result);
        }
    }
}
