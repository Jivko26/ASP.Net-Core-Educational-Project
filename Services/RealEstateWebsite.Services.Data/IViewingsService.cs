namespace RealEstateWebsite.Services.Data
{
    using System.Collections.Generic;

    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Viewings;
    using RealEstateWebsite.Web.ViewModels.Viewings;

    public interface IViewingsService
    {
        public IEnumerable<DayOfWeek> GetDaysOfWeek();

        public IEnumerable<HalfDay> GetHalfDays();

        void CreateViewing(string userId, int propertyId, PlanViewingFormModel viewingFormModel);

        IEnumerable<AllViewingsServiceModel> GetMyViewings(string userId);

        void CancelViewing(int viewingId);

    }
}
