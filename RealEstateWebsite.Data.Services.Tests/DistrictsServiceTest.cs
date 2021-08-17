
namespace RealEstateWebsite.Data.Services.Tests
{
    using Xunit;
    using Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Data.Models;
    using System.Linq;

    public class DistrictsServiceTest
    {
        [Fact]
        public void DistrictExistsShouldReturnTrueWhenDistrictExistd()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var districtsService = new DistrictsService(data);

            //Act

            data.Districts.Add(new District
            {
                Name = "Test",
            });

            data.SaveChanges();

            var result = districtsService.DistrictExists(1);

            //Assert

            Assert.True(result);
        }

        [Fact]
        public void DistrictExistsShouldReturnFalseWhenDistrictDoesNotExist()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var districtsService = new DistrictsService(data);

            //Act

            data.Districts.Add(new District
            {
                Name = "Test",
            });

            data.SaveChanges();

            var result = districtsService.DistrictExists(2);

            //Assert

            Assert.False(result);
        }

        [Fact]
        public void GetAllDistrictsShouldReturnCorrectCount()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var districtsService = new DistrictsService(data);

            //Act

            data.Districts.Add(new District
            {
                Name = "Test",
            });

            data.SaveChanges();

            var result = districtsService.GetAllDistricts().Count();

            //Assert

            Assert.Equal(1, result);
        }
    }
}
