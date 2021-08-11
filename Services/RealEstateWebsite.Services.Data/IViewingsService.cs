namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Viewings;

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

        IEnumerable<AllViewingsServiceModel> GetMyViewings(string userId);

        void CancelViewing(int viewingId);

    }
}
