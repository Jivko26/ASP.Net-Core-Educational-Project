namespace RealEstateWebsite.Web.Controllers
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RealEstateWebsite.Data.Models.Enum;
    using RealEstateWebsite.Services.Data.Interfaces;
    using RealEstateWebsite.Web.Infrastructure;
    using RealEstateWebsite.Web.ViewModels.Viewings;

    public class ViewingsController : Controller
    {
        private readonly IViewingsService viewingsService;

        public ViewingsController(IViewingsService viewingsService)
            => this.viewingsService = viewingsService;

        [Authorize]
        public IActionResult Plan(int propertyId)
        {
            var daysOfWeek = this.viewingsService.GetDaysOfWeek();
            var halfDays = this.viewingsService.GetHalfDays();

            return this.View(this.PrepareFormModel(daysOfWeek, halfDays));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Plan(int propertyId, PlanViewingFormModel planViewingFormModel)
        {
            var userId = this.User.Id();

            if (!this.ModelState.IsValid)
            {
                var daysOfWeek = this.viewingsService.GetDaysOfWeek();
                var halfDays = this.viewingsService.GetHalfDays();

                return this.View(this.PrepareFormModel(daysOfWeek, halfDays));
            }

            this.viewingsService.CreateViewing(userId, propertyId, planViewingFormModel);

            return this.RedirectToAction("SentViewing", "Information");
        }

        [Authorize]
        public IActionResult MyViewings()
        {
            var userId = this.User.Id();

            var usersViewings = this.viewingsService.GetMyViewings(userId);

            return this.View(usersViewings);
        }

        [Authorize]
        public IActionResult Cancel(int id)
        {
            this.viewingsService.CancelViewing(id);

            return this.RedirectToAction(nameof(this.MyViewings));
        }

        private PlanViewingFormModel PrepareFormModel(IEnumerable<RealEstateWebsite.Data.Models.Enum.DayOfWeek> dayOfWeeks, IEnumerable<HalfDay> halfDays)
        {
            return new PlanViewingFormModel
            {
                Days = dayOfWeeks,
                HalfDays = halfDays,
            };
        }
    }
}
