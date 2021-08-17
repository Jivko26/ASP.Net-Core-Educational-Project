namespace RealEstateWebsite.Data.Services.Tests
{
    using Xunit;
    using Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using System.Linq;

    public class PropertiesServiceTest
    {
        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void CreatePropertyShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            var result = data.Properties.Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void EditPropertyShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            propertyService.Edit(id, "New", address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            var result = data.Properties.First();

            //Assert

            Assert.Equal("New", result.Interior);
        }

        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void GetAllPropertisShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            var result = propertyService.GetAllProperties().Count();

            //Assert

            Assert.Equal(1, result);
        }


        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void GetPropertyByDistrictShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            data.Districts.Add(new District
            {
                Name = "samsung",
            });

            var result = propertyService.GetPropertyByDistrict(1);

            //Assert

            Assert.Equal(1, result.DistcrictId);
        }

        [Fact]
        public void GetPropertiesTypesSShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            var result = propertyService.GetPropertiesTypes().Count();

            //Assert

            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void GetPropertiesByDistrictShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            data.Districts.Add(new District
            {
                Name = "samsung",
            });

            var result = propertyService.GetPropertiesByDistrict(1).Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void GetPropertyByIdShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            data.RealEstateAgents.Add(new EstateAgent
            {
                Name = "SANTOS",
                ContactEmail = "mine@mine.com",
                Telephone = "0120312",
                WebSiteUrl = "mine.com",
                OfficeLocation = "here",
            });

            data.SaveChanges();

            var result = propertyService.GetPropertyById(1);

            //Assert

            Assert.Equal(interior, result.Interior);
            Assert.Equal(id, result.Id);
        }

        [Theory]
        [InlineData(1, "TEst", "addres", "url", 12, 2, 3, 4, 123, 1, 1, PropertyType.Apartment, 1223)]
        public void SetIsDeletedToTrueShouldWorkCorrectly(int id,
            string interior,
            string address,
            string pictureUrl,
            int livingArea,
            int rooms,
            int floor,
            int totalFloors,
            decimal price,
            int districtId,
            int estateAgentId,
            PropertyType propertyType,
            int? year)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var propertyService = new PropertiesService(data);

            //Act

            propertyService.CreateProperty(id, interior, address, pictureUrl, livingArea, rooms, floor, totalFloors, price, districtId, estateAgentId, propertyType, year);

            var result = data.Properties.First();

            propertyService.SetIsDeletedToTrue(result);

            //Assert

            Assert.True(result.IsDeleted);
        }
    }
}
