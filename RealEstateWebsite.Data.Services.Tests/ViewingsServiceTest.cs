namespace RealEstateWebsite.Data.Services.Tests
{
    using Xunit;
    using Common;
    using RealEstateWebsite.Services.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using System.Linq;
    using System;
    using RealEstateWebsite.Web.ViewModels.Viewings;

    public class ViewingsServiceTest
    {
        [Theory]
        [InlineData("me", "mine", "me@me.com", "12313", "testing", RealEstateWebsite.Data.Models.Enum.DayOfWeek.Friday, HalfDay.InTheAfternoon, "12312qas", 1)]
        public void CreateViewingShouldWorkCorrectly(string firstName,
            string lastName,
            string email,
            string phone,
            string description,
            RealEstateWebsite.Data.Models.Enum.DayOfWeek dayOfWeek,
            HalfDay halfDay,
            string userId,
            int propertyId)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var viewingsService = new ViewingsService(data);

            var viewingFormModel = new PlanViewingFormModel
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                Phone = phone,
                Description = description,
                Day = dayOfWeek,
                HalfDay = halfDay,
            };

            //Act

            viewingsService.CreateViewing(userId, propertyId, viewingFormModel);

            var result = data.Viewings.Count();

            //Assert

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("me", "mine", "me@me.com", "12313", "testing", RealEstateWebsite.Data.Models.Enum.DayOfWeek.Friday, HalfDay.InTheAfternoon, "12312qas", 1)]
        public void CancelViewingShouldWorkCorrectly(string firstName,
            string lastName,
            string email,
            string phone,
            string description,
            RealEstateWebsite.Data.Models.Enum.DayOfWeek dayOfWeek,
            HalfDay halfDay,
            string userId,
            int propertyId)
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var viewingsService = new ViewingsService(data);

            var viewingFormModel = new PlanViewingFormModel
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = email,
                Phone = phone,
                Description = description,
                Day = dayOfWeek,
                HalfDay = halfDay,
            };

            //Act

            viewingsService.CreateViewing(userId, propertyId, viewingFormModel);

            var result = data.Viewings.First();

            viewingsService.CancelViewing(result.Id);

            //Assert

            Assert.True(result.IsDeleted);
        }

        [Fact]
        public void GetDaysOfWeekShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var viewingService = new ViewingsService(data);

            //Act

            var result = viewingService.GetDaysOfWeek().Count();

            //Assert

            Assert.Equal(5, result);
        }

        [Fact]
        public void GetHalfDaysShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var viewingService = new ViewingsService(data);

            //Act

            var result = viewingService.GetHalfDays().Count();

            //Assert

            Assert.Equal(2, result);
        }

        [Fact]
        public void GetMyViewingsShouldWorkCorrectly()
        {
            //Arrange

            var data = InMemoryFactory.InitializeContext;

            var viewingsService = new ViewingsService(data);

            var viewingFormModel = new PlanViewingFormModel
            {
                FirstName = "dnes",
                LastName = "jorkov",
                EmailAddress = "j@j.com",
                Phone = "1213",
                Description = "ending",
                Day = RealEstateWebsite.Data.Models.Enum.DayOfWeek.Friday,
                HalfDay = HalfDay.InTheAfternoon,
            };

            //Act

            data.Users.Add(new ApplicationUser
            {
                UserName = "me",
            });

            data.SaveChanges();

            var userId = data.Users.Select(u => u.Id).First();

            data.Districts.Add(new District
            {
                Name = "Santoss"
            });

            data.Properties.Add(new Property
            {
                Interior = "Rest",
                PictureUrl = "asjdasmasd",
                Address = "mine 24",
                Type = PropertyType.Apartment,
                Price = 3444,
                EstateAgentId = 1,
                DistcrictId = 1,
            });

            data.SaveChanges();

            viewingsService.CreateViewing(userId, 1, viewingFormModel);

            var result = viewingsService.GetMyViewings(userId).Count();

            //Assert

            Assert.Equal(1, result);
        }
    }

}
