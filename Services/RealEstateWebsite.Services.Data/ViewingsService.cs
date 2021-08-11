namespace RealEstateWebsite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;

    public class ViewingsService : IViewingsService
    {
        private readonly ApplicationDbContext data;

        public ViewingsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void CreateViewing(
            string firstName,
            string lastName,
            string email,
            string phone,
            string description,
            RealEstateWebsite.Data.Models.Enum.DayOfWeek dayOfWeek,
            HalfDay halfDay,
            string userId,
            int propertyId)
        {
            var viewing = new Viewing
            {
                FirsName = firstName,
                LastName = lastName,
                EmailAddress = email,
                PhoneNumber = phone,
                Description = description,
                DayOfWeek = dayOfWeek,
                HalfDay = halfDay,
                AuthorId = userId,
                PropertyId = propertyId,
            };

            this.data.Viewings.Add(viewing);
            this.data.SaveChanges();
        }

        public IEnumerable<RealEstateWebsite.Data.Models.Enum.DayOfWeek> GetDaysOfWeek()
             => Enum.GetValues(typeof(RealEstateWebsite.Data.Models.Enum.DayOfWeek))
            .Cast<RealEstateWebsite.Data.Models.Enum.DayOfWeek>()
            .ToList();

        public IEnumerable<HalfDay> GetHalfDays()
             => Enum.GetValues(typeof(HalfDay))
            .Cast<HalfDay>()
            .ToList();
    }
}
