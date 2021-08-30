namespace RealEstateWebsite.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;
    using RealEstateWebsite.Data;
    using RealEstateWebsite.Data.Models;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.ServiceModels.Viewings;
    using RealEstateWebsite.Web.ViewModels.Viewings;

    public class ViewingsService : IViewingsService
    {
        private readonly ApplicationDbContext data;

        public ViewingsService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public void CancelViewing(int viewingId)
        {
            var viewing = this.data.Viewings.Find(viewingId);

            viewing.IsDeleted = true;

            this.data.SaveChanges();
        }

        public void CreateViewing(string userId, int propertyId, PlanViewingFormModel viewingFormModel)
        {
            var viewing = new Viewing
            {
                FirsName = viewingFormModel.FirstName,
                LastName = viewingFormModel.LastName,
                EmailAddress = viewingFormModel.EmailAddress,
                PhoneNumber = viewingFormModel.Phone,
                Description = viewingFormModel.Description,
                DayOfWeek = viewingFormModel.Day,
                HalfDay = viewingFormModel.HalfDay,
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

        public IEnumerable<AllViewingsServiceModel> GetMyViewings(string userId)
            => this.data.Viewings
            .Include(v => v.Property)
            .ThenInclude(p => p.District)
            .Where(v => v.AuthorId == userId && !v.IsDeleted)
            .Select(v => new AllViewingsServiceModel
            {
                ViewingId = v.Id,
                ViewingsPropertyImageUrl = v.Property.PictureUrl,
                ViewingsPropertyAddress = v.Property.Address,
                ViewingsPropertyType = v.Property.Type.ToString(),
                ViewingsPropertyDistrict = v.Property.District.Name,
                CreatedOn = v.CreatedOn,
            })
            .OrderByDescending(v => v.CreatedOn)
            .ToList();

    }
}
