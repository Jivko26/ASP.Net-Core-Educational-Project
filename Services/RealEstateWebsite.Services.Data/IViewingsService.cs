namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models.Enum;

    public interface IViewingsService
    {
        public IEnumerable<DayOfWeek> GetDaysOfWeek();

        public IEnumerable<HalfDay> GetHalfDays();

        void CreateViewing(
            string firstName,
            string lastName,
            string email,
            string phone,
            string description,
            DayOfWeek dayOfWeek,
            HalfDay halfDay,
            string userId,
            int propertyId);
    }
}
